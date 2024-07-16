using AJP_AML_Service.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AMLService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AMLScanRequestController : ControllerBase
    {
        private readonly API_DB_Context _context;
        private static Stopwatch timer = new Stopwatch();

        public AMLScanRequestController(API_DB_Context context)
        {
            _context = context;
        }

        private async Task<bool> IsDatabaseConnectedAsync()
        {
            try
            {
                await _context.Database.OpenConnectionAsync();
                _context.Database.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine($"Database connection failed: {ex.Message}");
                return false;
            }
        }

        // This method will handle the API callback
        [HttpPost("ScanOnline")]
        public async Task<IActionResult> ScanOnline(ScanRequestModel callback)
        {
            timer.Start();
            try
            {
                var response = new ScanResponseModel { RtnHandshake = "N" };

                // Check if any required parameter is empty
                if (string.IsNullOrEmpty(callback.UniqueNo) || string.IsNullOrEmpty(callback.ScanID) || string.IsNullOrEmpty(callback.RtnHit))
                {
                    return Ok(response);
                }

                string ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                int responseStatusCode = HttpContext.Response.StatusCode;

                // Check database connection
                if (!await IsDatabaseConnectedAsync())
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Database connection is not available.");
                }

                // Create SQL parameters including the output parameter
                var uniqueNoParam = new SqlParameter("@UniqueNo", callback.UniqueNo);
                var scanIdParam = new SqlParameter("@ScanID", callback.ScanID);
                var rtnHitParam = new SqlParameter("@RtnHit", callback.RtnHit);
                var rtnHandshakeParam = new SqlParameter
                {
                    ParameterName = "@RtnHandshake",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 1,
                    Direction = ParameterDirection.Output
                };

                // Execute the stored procedure
                var result = await _context.Database.ExecuteSqlRawAsync(
                    "exec [SP_DECISION_AML] @UniqueNo, @ScanID, @RtnHit, @RtnHandshake OUTPUT",
                    uniqueNoParam, scanIdParam, rtnHitParam, rtnHandshakeParam);

                // Convert the result to a string
                response.RtnHandshake = rtnHandshakeParam.Value?.ToString();

                LogCallback(callback, response, Request.Path, ipAddress, responseStatusCode);
                return Ok(response); // Return a 200 OK response to the sender

            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        // Method to log the callback into the database
        private void LogCallback(ScanRequestModel callback, ScanResponseModel response, string strRequestUrl, string strIPAdress, int ReponseStatus)
        {
            timer.Stop();
            var logEntry = new APILogRequestModel
            {
                request_direction = "IN",
                request_url = strRequestUrl,
                request_method = "POST",
                request_header = "",
                request_body = JsonConvert.SerializeObject(callback),
                response_body = JsonConvert.SerializeObject(response),
                response_error = ReponseStatus.ToString(),
                regno = callback.UniqueNo,
                time_load = timer.Elapsed.Seconds + (decimal)timer.Elapsed.Milliseconds / 1000M,
                user_id = "AMLService",
                create_date = DateTime.UtcNow,
                ip_address = strIPAdress ?? "Unknown"
            };

            timer.Reset();

            _context.APILogRequest.Add(logEntry);
            _context.SaveChanges();
        }
    }
}

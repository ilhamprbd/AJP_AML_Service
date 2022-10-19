using API_TEST.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace API_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetParticipantFundController : ControllerBase
    {

        private readonly API_DB_Context _context;

        public GetParticipantFundController(API_DB_Context context)
        {
            _context = context;
        }




        // GET: api/Ouputs
        [HttpPost]
        // public async Task<ActionResult<IEnumerable<NBApplication>>> GetOuput(Input input)
        public async Task<ActionResult<IEnumerable<GetParticipantFundOutput>>> GetOuput(GetParticipantFundInput input)
        {
            string StoredProc = "exec [SP_API_PARTICIPANT_FUND] " +
              " '" + input.policy_id + "'," + "'" + input.certificate_no + "'," + "'" + input.date.ToString("yyyy-MM-dd") + "'," + " " + input.option + "";
            try
            {
                return await _context.GetParticipantFundOutput.FromSqlRaw(StoredProc).ToListAsync();
            }catch(Exception ex)
            {
                return await _context.GetParticipantFundOutput.FromSqlRaw(StoredProc).ToListAsync();
            }
        }
    }
}


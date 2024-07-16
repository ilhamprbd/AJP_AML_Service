using AMLService.DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMLService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDetailProviderController : ControllerBase
    {
        private readonly API_DB_Context _context;

        public GetDetailProviderController(API_DB_Context context)
        {
            _context = context;
        }




        // GET: api/Ouputs
        [HttpPost]
        public async Task<ActionResult<IEnumerable<GetDetailProviderOutput>>> GetOuputssss(GetDetailProviderInput input)
        {
            string StoredProc = "exec SP_API_POST_PROVIDER " +
             "'" + input.strCode + "'";


            return await _context.GetDetailProviderOutput.FromSqlRaw(StoredProc).ToListAsync();
        }




    }
}

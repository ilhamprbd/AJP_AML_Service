using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_TEST.DB.Models;

namespace API_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OuputsController : ControllerBase
    {
        private readonly API_DB_Context _context;

        public OuputsController(API_DB_Context context)
        {
            _context = context;
        }

        // GET: api/Ouputs
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Ouput>>> GetOuput(Input input)
        {
            string StoredProc = "exec [Submit_ONSUB_AJK] " +
             "'" + input.strErrorCode + "'," +
             "'" + input.strErrorDesc + "'," +
             "'" + input.strProposalGeneralId + "'";

            
            return await _context.Ouput.FromSqlRaw(StoredProc).ToListAsync();
        }



        //// GET: api/Ouputs/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Ouput>> GetOuput(string id)
        //{
        //    var ouput = await _context.Ouput.FindAsync(id);

        //    if (ouput == null)
        //    {
        //        return NotFound();
        //    }

        //    return ouput;
        //}

        //// PUT: api/Ouputs/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOuput(string id, Ouput ouput)
        //{
        //    if (id != ouput.strProposalGeneralId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(ouput).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OuputExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Ouputs
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Ouput>> PostOuput(Ouput ouput)
        //{
        //    _context.Ouput.Add(ouput);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (OuputExists(ouput.strProposalGeneralId))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetOuput", new { id = ouput.strProposalGeneralId }, ouput);
        //}

        //// DELETE: api/Ouputs/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOuput(string id)
        //{
        //    var ouput = await _context.Ouput.FindAsync(id);
        //    if (ouput == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Ouput.Remove(ouput);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool OuputExists(string id)
        //{
        //    return _context.Ouput.Any(e => e.strProposalGeneralId == id);
        //}
    }
}

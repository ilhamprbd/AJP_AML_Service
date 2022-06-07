using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_TEST.DB.Models;

namespace API_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestOutputsController : ControllerBase
    {
        private readonly API_DB_Context _context;



        private static List<TestOutput> strArrSoal()
        {
            IList<TestOutput> studentList = new List<TestOutput>()
            {
                new TestOutput()
                    {strMerk = "Ford", strTipe = "Fiesta", strTransmisi = "Manual", strHarga = "Rp. 120,000,000"},
                new TestOutput()
                    {strMerk = "Ford", strTipe = "Fiesta", strTransmisi = "Manual", strHarga = "Rp. 134,000,000"},
                new TestOutput()
                    {strMerk = "Ford", strTipe = "Fiesta", strTransmisi = "Automatic", strHarga = "Rp. 140,000,000"},
                new TestOutput()
                    {strMerk = "Ford", strTipe = "Fiesta", strTransmisi = "Automatic", strHarga = "Rp. 150,000,000"},
                new TestOutput()
                    {strMerk = "Ford", strTipe = "Focus", strTransmisi = "Manual", strHarga = "Rp. 330,000,000"},
                new TestOutput()
                    {strMerk = "Ford", strTipe = "Focus", strTransmisi = "Manual", strHarga = "Rp. 335,000,000"},
                new TestOutput()
                    {strMerk = "Ford", strTipe = "Focus", strTransmisi = "Manual", strHarga = "Rp. 350,000,000"},
                new TestOutput()
                    {strMerk = "Ford", strTipe = "Focus", strTransmisi = "Automatic", strHarga = "Rp. 360,000,000"},
                new TestOutput()
                    {strMerk = "VW", strTipe = "Golf", strTransmisi = "Manual", strHarga = "Rp. 350,000,000"},
                new TestOutput()
                    {strMerk = "VW", strTipe = "Golf", strTransmisi = "Automatic", strHarga = "Rp. 370,000,000"}

            };

            return (List<TestOutput>)studentList;
        }



        public TestOutputsController(API_DB_Context context)
        {
            _context = context;
        }

        // GET: api/TestOutputs
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TestOutput>>> GetTestOuput()
        //{


        //    return await _context.TestOuput.ToListAsync();
        //}


        [HttpGet]
        public List<TestOutput> Get()
        {
            List<TestOutput> priceList = strArrSoal();
            List<TestOutput> listReturn = new List<TestOutput>();
            
            int count = 0;


            foreach (TestOutput var in priceList)
            {

                TestOutput testOutputs = new TestOutput();


                if (count == 0)
                {
                    testOutputs.strMerk = var.strMerk;
                    testOutputs.strTipe = var.strTipe;
                    testOutputs.strTransmisi = var.strTransmisi;
                    testOutputs.strHarga = var.strHarga;
                }
                else
                {
                    testOutputs.strMerk = testOutputs.strMerk != var.strMerk ? var.strMerk : "asd" ;
                    testOutputs.strTipe = testOutputs.strTipe != var.strTipe ? var.strTipe : "asd";
                    testOutputs.strTransmisi = testOutputs.strTransmisi != var.strTransmisi ? var.strTransmisi : "asd";
                    testOutputs.strHarga = testOutputs.strHarga != var.strHarga ? var.strHarga : "asd";
                }



                listReturn.Add(new TestOutput
                {
                    strMerk = testOutputs.strMerk,
                    strTipe = testOutputs.strTipe,
                    strTransmisi = testOutputs.strTransmisi,
                    strHarga = testOutputs.strHarga
                }) ;

                count++;

            }


            return priceList;

        }


        private bool TestOutputExists(string id)
        {
            return _context.TestOuput.Any(e => e.strMerk == id);
        }
    }
}

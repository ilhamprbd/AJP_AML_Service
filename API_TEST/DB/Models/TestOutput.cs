using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace API_TEST.DB.Models
{
    public class TestOutput
    {

        [Key]
        public string strMerk { get; set; }
        public string strTipe { get; set; }
        public string strTransmisi { get; set; }
        public string strHarga { get; set; }


    }
}

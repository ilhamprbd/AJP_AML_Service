using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;



namespace API_TEST.DB.Models
{


    public class Ouput
    {
        [Key]
        public string ErrorCode { get; set; }
        public string ErrorDesc { get; set; }
        
    }
}

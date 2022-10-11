using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_TEST.DB.Models
{
    public class NBApplication
    {
        [Key]
        public string app_id { get; set; }
        public string policy_holder { get; set; }
        public string policy_id { get; set; }
        public string package_code { get; set; }
        public DateTime create_date { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string business_unit_code { get; set; }

    }
}

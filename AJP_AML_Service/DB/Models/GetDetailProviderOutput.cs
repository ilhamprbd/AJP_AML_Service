using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMLService.DB.Models
{
    public class GetDetailProviderOutput
    {
        [Key]
        public string provider_code { get; set; }
        public string provider_name { get; set; }
        public string provider_desc { get; set; }
        public string provider_type { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city_code { get; set; }
        public string province_code { get; set; }

    }
}

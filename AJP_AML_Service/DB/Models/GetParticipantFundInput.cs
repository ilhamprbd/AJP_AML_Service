using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AMLService.DB.Models
{
    public class GetParticipantFundInput
    {
        [Key]
        public string policy_id { get; set; }
        public string certificate_no { get; set; }
        public DateTime date { get; set; }
        public int option { get; set; }

    }
}

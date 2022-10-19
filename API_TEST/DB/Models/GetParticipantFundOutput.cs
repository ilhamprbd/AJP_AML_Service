using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_TEST.DB.Models
{
	[Keyless]
	public class GetParticipantFundOutput
    {

	
		public string policy_id { get; set; }
		public string certificate_no { get; set; }
		public string npp { get; set; }
		public string contributor_code { get; set; }
		public string fund_name { get; set; }
		public decimal iuran { get; set; }
		public decimal penarikan_dana { get; set; }
		public decimal biaya { get; set; }
		public decimal fund_switching_in { get; set; }
		public decimal fund_switching_out { get; set; }
		public decimal hasil_investasi { get; set; }
		public decimal total_asset { get; set; }
		public decimal total_unit { get; set; }
		public decimal harga_unit { get; set; }

				
	}
}

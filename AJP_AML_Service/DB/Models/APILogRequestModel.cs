using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AJP_AML_Service.DB.Models
{
    [Table("api_log_request")]
    public class APILogRequestModel
    {
        public long id { get; set; }
        public string request_direction { get; set; }
        public string request_url { get; set; }
        public string request_method { get; set; }
        public string request_header { get; set; }
        public string request_body { get; set; }
        public string response_body { get; set; }
        public string response_error { get; set; }
        public decimal time_load { get; set; }
        public string regno { get; set; }
        public string user_id { get; set; }
        public DateTime create_date { get; set; }
        public string ip_address { get; set; }
    }

}
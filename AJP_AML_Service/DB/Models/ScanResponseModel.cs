using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AJP_AML_Service.DB.Models
{
    [Keyless]
    public class ScanResponseModel
    {
     
        public string RtnHandshake { get; set; }
    }
}
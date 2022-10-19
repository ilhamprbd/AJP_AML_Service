using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_TEST.DB.Models
{
    public class GetCompanyOutput
    {
        [Key]
        public string kode_perusahaan { get; set; }
        public string nama_perusahaan { get; set; }
        public string bidang_usaha { get; set; }
        public string alamat { get; set; }
        public string status { get; set; }
    }
}

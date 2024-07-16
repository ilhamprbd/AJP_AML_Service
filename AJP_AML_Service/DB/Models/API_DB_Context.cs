using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using AMLService.DB.Models;


namespace AJP_AML_Service.DB.Models
{
    public partial class API_DB_Context : DbContext
    {

        public API_DB_Context()
        {

        }

        public API_DB_Context(DbContextOptions<API_DB_Context>options) : base(options)
        {

        }

        public DbSet<ScanResponseModel> ScanResponses { get; set; }

        public DbSet<APILogRequestModel> APILogRequest { get; set; }

        //public DbSet<GetDetailProviderOutput> GetDetailProviderOutput { get; set; }

        //public DbSet<GetCompanyOutput> GetCompanyOutput { get; set; }

        //public DbSet<GetParticipantFundOutput> GetParticipantFundOutput { get; set; }



    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_TEST.DB.Models;


namespace API_TEST.DB.Models
{
    public partial class API_DB_Context : DbContext
    {

        public API_DB_Context()
        {

        }

        public API_DB_Context(DbContextOptions<API_DB_Context>options) : base(options)
        {

        }


        public DbSet<API_TEST.DB.Models.GetDetailProviderOutput> GetDetailProviderOutput { get; set; }

        public DbSet<API_TEST.DB.Models.GetCompanyOutput> GetCompanyOutput { get; set; }

        public DbSet<API_TEST.DB.Models.GetParticipantFundOutput> GetParticipantFundOutput { get; set; }


    }
}

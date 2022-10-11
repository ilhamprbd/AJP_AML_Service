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

        public DbSet<API_TEST.DB.Models.Ouput> Ouput { get; set; }

        public DbSet<API_TEST.DB.Models.GetDetailProviderControllerOutput> GetDetailProviderControllerOutput { get; set; }

        public DbSet<API_TEST.DB.Models.NBApplication> GetNBApplication { get; set; }

        public DbSet<API_TEST.DB.Models.TestOutput> TestOuput { get; set; }

    }
}

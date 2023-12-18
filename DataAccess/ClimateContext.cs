using ICareAboutClimateBE.Models;
using Microsoft.EntityFrameworkCore;

namespace Epistimology_BE.DataAccess
{
    public class ClimateContext : DbContext
    {
        public readonly IConfiguration Configuration;
        public DbSet<FormResponse> formResponses { get; set; }
        public DbSet<FormQuestionResponse> individualQuestionResponses { get; set; }

        public ClimateContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            //options.UseSqlServer(connectionString);
        }
    }
}
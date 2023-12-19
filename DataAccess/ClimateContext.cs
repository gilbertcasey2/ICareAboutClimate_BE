using ICareAboutClimateBE.Models;
using Microsoft.EntityFrameworkCore;

namespace ICareAboutClimate.DataAccess
{
    public class ClimateContext : DbContext
    {
        // public readonly IConfiguration Configuration;
        public DbSet<FormResponse> formResponses { get; set; }
        public DbSet<FormQuestionResponse> individualQuestionResponses { get; set; }

        // public ClimateContext(IConfiguration configuration)
        // {
        //     Configuration = configuration;
        // }
        public ClimateContext(DbContextOptions<ClimateContext> options): base(options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder options)
        // {
        //     var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        //     options.UseSqlServer(connectionString);
        // }
    }
}

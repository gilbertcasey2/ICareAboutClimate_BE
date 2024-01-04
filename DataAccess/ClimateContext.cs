using ICareAboutClimateBE.Migrations;
using ICareAboutClimateBE.Models;
using Microsoft.EntityFrameworkCore;

namespace ICareAboutClimate.DataAccess
{
    public class ClimateContext : DbContext
    {
        // public readonly IConfiguration Configuration;
        public DbSet<FormResponse> formResponses { get; set; }
        public DbSet<FormQuestionResponse> individualQuestionResponses { get; set; }

        public DbSet<InProgressResponse> inProgressQuestionResponses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //configures form responses to individual questions one-to-many relationship
            modelBuilder.Entity<FormQuestionResponse>()
                .HasOne<FormResponse>(c => c.formResponse)
                .WithMany(p => p.responses);

            //configures form responses to individual questions in progress one-to-many relationship
            modelBuilder.Entity<InProgressResponse>()
                .HasOne<FormResponse>(c => c.formResponse)
                .WithMany(p => p.inProgressResponses);
                
        }


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

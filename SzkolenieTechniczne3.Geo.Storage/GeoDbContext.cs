using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SzkolenieTechniczne3.Geo.Storage.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SzkolenieTechniczne3.Geo.Storage
{
    public class GeoDbContext : DbContext
    {
        private IConfiguration _configuration { get; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryTranslation> CountryTranslations { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CityTranslation> CityTranslations { get; set; }
        public GeoDbContext(IConfiguration configuration):base()
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"server=(localdb)\MYSSQLLocalDB;database=geo-dev;trusted_connection=true;",

            //optionsBuilder.UseSqlServer(@"server = 10.200.2.28; Database = geo-dev-w65575; User Id = stud; Password =wsiz; ",
             x => x.MigrationsHistoryTable("__EFMigrationHistory", "Geo"));
           

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

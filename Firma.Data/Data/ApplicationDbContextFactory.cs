using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Firma.Data.Data;

namespace Projekt.Data.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<FirmaContext>
    {
        public FirmaContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FirmaContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=FirmaContext2023;Trusted_Connection=True;MultipleActiveResultSets=true;");

            return new FirmaContext(optionsBuilder.Options);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace G9L.Data.EFs
{
    class G9LDbContextFactory : IDesignTimeDbContextFactory<G9LDbContext>
    {
        public G9LDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .Build();

            var connectionString = configurationRoot.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<G9LDbContext>();

            optionsBuilder.UseSqlServer(connectionString);
            return new G9LDbContext(optionsBuilder.Options);
        }
    }
}

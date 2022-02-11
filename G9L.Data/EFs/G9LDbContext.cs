using G9L.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace G9L.Data.EFs
{
    public class G9LDbContext : DbContext
    {
        public G9LDbContext(DbContextOptions<G9LDbContext> options) : base(options)
        {

        }
        protected string DefaultConnection = @"Server=.;Database=G9L;Trusted_Connection=True;";
        public DbSet<Import> Imports { get; set; }
        public DbSet<ImportDetails> ImportDetails { get; set; }
        public DbSet<Export> Exports { get; set; }
        public DbSet<ExportDetails> ExportDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<ManufactureOfProduct> ManufactureOfProducts { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserPrivilege> UserPrivileges { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ImportDetails>().HasKey(table => new {
                table.ImportID,
                table.ProductID
            });
            builder.Entity<ExportDetails>().HasKey(table => new {
                table.ExportID,
                table.ProductID
            });

            builder.Entity<ManufactureOfProduct>().HasKey(table => new
            {
                table.ProductID,
                table.ManufactureID
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DefaultConnection);// thiết lập làm việc với SqlServer
        }
    }
}

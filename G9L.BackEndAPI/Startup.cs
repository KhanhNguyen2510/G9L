using G9L.Aplication.Catalog.Export;
using G9L.Aplication.Catalog.Import;
using G9L.Aplication.Catalog.Manufacture;
using G9L.Aplication.Catalog.Product;
using G9L.Aplication.Catalog.ProductType;
using G9L.Aplication.Catalog.Provider;
using G9L.Data.EFs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace G9L.BackEndAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<G9LDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            
            services.AddControllers();

            services.AddTransient<IProviderSevice, ProviderSevice>();
            services.AddTransient<IManufactureSevice, ManufactureSevice>();
            services.AddTransient<IProductSevice, ProductSevice>();
            services.AddTransient<IImportSevice, ImportSevice>();
            services.AddTransient<IExportSevice, ExportSevice>();
            services.AddTransient<IProductTypeSevice, ProductTypeSevice>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "G9L.BackEndAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseSwagger();

            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "G9L.BackEndAPI v1"));

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

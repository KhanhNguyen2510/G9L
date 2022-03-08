using G9L.IntergrationAPI.Export;
using G9L.IntergrationAPI.Import;
using G9L.IntergrationAPI.Manufacture;
using G9L.IntergrationAPI.NewFolder;
using G9L.IntergrationAPI.Product;
using G9L.IntergrationAPI.ProductType;
using G9L.IntergrationAPI.Provider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace G9L.Wedsite
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
            services.AddHttpClient();
            services.AddControllersWithViews();

            services.AddTransient<IProductTypeApiClient, ProductTypeApiClient>();
            services.AddTransient<IProductApiClient, ProductApiClient>();
            services.AddTransient<IProviderApiClient, ProviderApiClient>();
            services.AddTransient<IManufactureApiClient, ManufactureApiClient>();
            services.AddTransient<IImportApiClient, ImportApiClient>();
            services.AddTransient<IExportApiClient, ExportApiClient>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IShoppingCardApiClient, ShoppingCardApiClient>();

            IMvcBuilder builder = services.AddRazorPages();

            var envirament = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (envirament == Environments.Development)
            {
                builder.AddRazorRuntimeCompilation();

            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ProductType}/{action=Index}/{id?}");
            });
        }
    }
}

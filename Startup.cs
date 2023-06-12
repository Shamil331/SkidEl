using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace SkidEl
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SkidElContext>();
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "Main",
                    pattern: "main",
                    defaults: new { controller = "SkidEl", action = "MainPage" });
                endpoints.MapControllerRoute(name: "discounts",
                    pattern: "discounts",
                    defaults: new { controller = "SkidEl", action = "DiscountsListPage" });
                endpoints.MapControllerRoute(name: "discounts",
                    pattern: "discount/{_discount}",
                    defaults: new { controller = "SkidEl", action = "DiscountPage" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=SkidEl}/{action=MainPage}");
            });
        }
    }
}

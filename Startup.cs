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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // этот метод был пустой
            //Enable Cors
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //});
            services.AddDbContext<SkidElContext>();
            services.AddControllersWithViews();
            //services.AddMvc(options => options.EnableEndpointRouting = false);
            //JsonSerializer
            //services.AddControllersWithViews().AddNewtonsoftJson(options=>
            //options.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            //    .AddNewtonsoftJson(optoins=> optoins.SerializerSettings.ContractResolver
            //    =new DefaultContractResolver());
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //Enable Cors
            //app.UseCors(options=>options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();
            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers(); // Маршрутизация на конотроллеры
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "Main",
                    pattern: "main",
                    defaults: new { controller = "SkidEl", action = "MainPage" });
                endpoints.MapControllerRoute(name: "discounts",
                    pattern: "discounts/{category}/{page}",
                    defaults: new { controller = "SkidEl", action = "DiscountsListPage" });
                endpoints.MapControllerRoute(name: "discounts",
                    pattern: "discount/{_discount}",
                    defaults: new { controller = "SkidEl", action = "DiscountPage" });
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=SkidEl}/{action=MainPage}");
            });
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=SkidEl}/{action=MainPage}");
            //    routes.MapRoute(
            //        name: "main",
            //        template: "{controller=SkidEl}/{action=MainPage}/sale/{*product}");
            //    routes.MapRoute(
            //        name: "discount",
            //        template: "{controller=SkidEl}/{action=DiscountsListPage}/discounts/{*category}/{*page}");
            //});

        }
    }
}

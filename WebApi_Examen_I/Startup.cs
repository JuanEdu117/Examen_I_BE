using BLL.Interfaces;
using BLL.MongoDB;
using BLL.SQLServer;
using DAL.Interfaces;
using DAL.MongoDB;
using DAL.SQLServer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_Examen_I
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
            services.AddControllersWithViews();
            //INYECCIONES DEPENDENCIA MONGODB
            services.AddTransient(typeof(IArticulo_BLL), typeof(cls_Articulo_BLL));
            services.AddTransient(typeof(IArticulo_DAL), typeof(cls_Articulo_DAL));
            //INYECCIONES DEPENDENCIA SQLSERVER
            services.AddTransient(typeof(IPersona_BLL), typeof(cls_Persona_BLL));
            services.AddTransient(typeof(IPersona_DAL), typeof(cls_Persona_DAL));
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
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Persona}/{action=Index}/{id?}");
            });
        }
    }
}

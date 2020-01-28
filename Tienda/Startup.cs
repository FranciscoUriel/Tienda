using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Tienda.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Tienda.Persistence.Entities;


namespace Tienda
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages().AddRazorPagesOptions(options => {
                options.Conventions.AuthorizeFolder("/Carritos");
                options.Conventions.AuthorizeFolder("/Categoria");
                options.Conventions.AuthorizeFolder("/Productos");
                options.Conventions.AuthorizeFolder("/Sales");


            });
            services.AddDbContext<TiendaContext>(options => 
             options.UseSqlServer(Configuration.GetConnectionString("TiendaContext")));

            services.AddDefaultIdentity<Usuarios>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddDefaultUI()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TiendaContext>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}

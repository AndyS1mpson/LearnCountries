using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnCountries.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.Design;
using LearnCountries.Interfaces;
using LearnCountries.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnCountries
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
            
            //Customize context
            services.AddDbContext<ApplicationDbContext>(options 
                => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<ICountryRepository,CountryRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // services.AddRazorPages().AddRazorPagesOptions(options =>
            // {
            //     options.Conventions.AddFolderRouteModelConvention(
            //     "/Login", model => {});
            // });

            
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();   
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseStatusCodePages();
            app.UseSession();
            app.UseAuthorization();

            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapRazorPages();
            // });
            
            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

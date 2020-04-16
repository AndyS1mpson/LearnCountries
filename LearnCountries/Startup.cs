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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

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

            //services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => 
            {
                options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/LogIn");
            });

            
            services.AddRazorPages();
            services.AddControllers();
            services.AddMvc();

            //services.AddSession();
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
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
            app.UseStaticFiles();       // connect static фfiles
            app.UseAuthorization();
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapRazorPages(); //connect routing to controllers
            });
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapControllerRoute(
            //         name: "default",
            //         pattern: "{controller=Home}/{action=Index}/{id?}");
            // });
        }
    }
}

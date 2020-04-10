using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting;
using Kursova.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Kursova.DAL.EF;
using Kursova.DAL.Entities;

using Kursova.BLL.Services;
using Kursova.BLL.Interfaces;
using Kursova.DAL.Repositories;

using Kursova.DAL.Interfaces;
namespace Kursova
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<KursovaDbContext>(options => options.UseSqlServer(connection));
            services.AddRazorPages();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => 
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });
            services.AddControllersWithViews();
           
                services.AddDistributedMemoryCache();
                services.AddSession();
            services.AddMvc();
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IStudentService,StudentService>();
            services.AddScoped<IStudentService, StudentService>();


            // services.AddTransient<IStudentService, StudentService>;
            services.AddTransient<ITeacherService, TeacherService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.ConfigureApplicationCookie(options => options.LoginPath = "/Login");
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting();
            app.UseHttpsRedirection();

            app.UseAuthentication();    
            app.UseAuthorization();     

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
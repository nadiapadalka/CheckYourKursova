using Kursova.BLL.Interfaces;
using Kursova.BLL.Services;
using Kursova.DAL.EF;
using Kursova.DAL.Interfaces;
using Kursova.DAL.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Owin;

using Owin;
[assembly: OwinStartup(typeof(Kursova.Startup))]
namespace Kursova
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = this.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<KursovaDbContext>(options => options.UseSqlServer(connection));
            services.AddRazorPages();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Login");
                });
            services.AddControllersWithViews();
            services.AddMvc();
            services.AddTransient<IUnitOfWork, EFUnitOfWork>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<IAdminService, AdminService>();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.Configure<IISOptions>(options =>
            {
                options.ForwardClientCertificate = false;
            });

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Login");
	    services.AddSignalR(options => options.EnableDetailedErrors = true);
        }
	[Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
	    app.UseFileServer();
	    app.UseSignalR(routes =>
            {
                routes.MapHub<Hubs.NotifyHub>("/notifications");
            });
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
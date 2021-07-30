using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymManagerWebApp.Services;
using GymManagerWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GymManagerWebApp.Models;
using GymManagerWebApp.Services.CarnetService;
using GymManagerWebApp.Services.FileService;
using GymManagerWebApp.Services.RolesService;
using GymManagerWebApp.Services.ReservationService;
using GymManagerWebApp.dbMock;

namespace GymManagerWebApp
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<GymManagerContext>(o => o.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddIdentity<User, IdentityRole>(options => { options.Password.RequireNonAlphanumeric = false; }).AddEntityFrameworkStores<GymManagerContext>();

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.ConfigureApplicationCookie(config => 
            config.LoginPath = _configuration["Application:LoginPath"]);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICarnetService, CarnetService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ICalendarEventService, CalendarEventService>();
            services.AddScoped<IReservationService, ReservationService>();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "User",
                    pattern: "{controller=User}/{action=SignIn}/{id?}");
            });

            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetService<GymManagerContext>();

           context.Database.EnsureDeleted();
           context.Database.Migrate();
           ContextMock.MockExampleData(context);
        }
    }
}

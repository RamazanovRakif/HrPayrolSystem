using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayrollSystem.DAL;
using PayrollSystem.Models;

namespace PayrollSystem
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc();
            services.AddDbContext<PayrollDbContext>(x =>
            {
                x.UseSqlServer(Configuration["ConnectionStrings:MyConnection"]);
            });
            services.AddIdentity<Worker, IdentityRole>()
                .AddEntityFrameworkStores<PayrollDbContext>()
                    .AddDefaultTokenProviders();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Account/Login";
                        options.LogoutPath = "/Account/Logout";
                    });

            services.AddAuthorization(options =>
            {

                options.AddPolicy("Admin",
                    authBuilder =>
                    {
                        authBuilder.RequireRole("Admin");
                    });

            });

            services.AddAuthorization(options =>
            {

                options.AddPolicy("PayrollSpecalist",
                    authBuilder =>
                    {
                        authBuilder.RequireRole("PayrollSpecalist");
                    });

            });

            services.AddAuthorization(options =>
            {

                options.AddPolicy("HR",
                    authBuilder =>
                    {
                        authBuilder.RequireRole("HR");
                    });

            });

            services.Configure<IdentityOptions>(x =>
            {
                x.Password.RequireUppercase = true;
                x.Password.RequireLowercase = true;


            });
         
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
           // app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
            });
            
        }
    }
}

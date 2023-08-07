using BusinessLayer.Services.Account;
using BusinessLayer.Services.InterFace;
using DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SendEmail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BigStore
{
    public class Startup
    {
        public IConfiguration _configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();



            #region Athentication
            services.AddAuthentication(op =>
            {
                op.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                op.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                op.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }

            )
            .AddCookie(options =>
              {
                  options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
                  options.LoginPath = "/Login";
                  options.AccessDeniedPath = "/LogOut";
              });
            #endregion

            #region Context
            services.AddDbContext<BigStoreContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("BigStoreConnection"));
            });
            #endregion

            #region Ioc
            services.AddTransient<IAccount, Account>();
            #endregion

            #region SendEmail
            services.AddTransient<IViewRenderService, RenderViewToString>();
            #endregion
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();


            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute("areas", "UserPanel", "{controller=Home}/{action=Index}/{id?}");



            });


        }
    }
}

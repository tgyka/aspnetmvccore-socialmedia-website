using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Application.DependencyInjection;
using SocialMedia.Data;
using SocialMedia.Data.DependencyInjection;
using SocialMedia.Helper.DependencyInjection;

namespace SocialMedia.Web
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
   

            services.AddAuthentication("CookieSchema")
                    .AddCookie("CookieSchema", option => {
                        option.AccessDeniedPath = "/account/accessDenied";
                        option.LoginPath = "/account/login";
                        option.LogoutPath = "/account/logout";
                    }
                );


            services.AddDbContext<SocialMediaDbContext>();

            services.AddSession();
            services.AddHttpContextAccessor();


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            //Layer injections
            AddHelperDependencies.ConfigureServices(services);
            AddDataDependencies.ConfigureServices(services,Configuration);
            AddApplicationDependencies.ConfigureServices(services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseSession();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}

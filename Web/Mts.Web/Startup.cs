using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mts.Core.Common;
using Mts.Core.Interface;
using Mts.Core.Interface.Service;
using Mts.Infrastructure.Data;
using Mts.Infrastructure.Data.Repository;
using Mts.Infrastructure.Service;
using Mts.Infrastructure.Service.Services;
using Entity = Mts.Core.Entity;
using Dto = Mts.Core.Dto;
using Config = Mts.Core.Dto.Config;
namespace Mts.Web
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
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ICryptography, Cryptography>();
            services.AddTransient<CrudRepository<Entity.RegistrationRequest>, CrudRepository<Entity.RegistrationRequest>>();
            services.AddTransient<CrudRepository<Entity.User>,CrudRepository<Entity.User>>();
            services.AddTransient<CrudRepository<Entity.Business>, CrudRepository<Entity.Business>>();
            services.AddTransient<CrudRepository<Entity.UserBusiness>, CrudRepository<Entity.UserBusiness>>();
            services.AddTransient<CrudRepository<Entity.Role>, CrudRepository<Entity.Role>>();
            services.AddTransient<CrudRepository<Entity.RoleApplicationFeature>, CrudRepository<Entity.RoleApplicationFeature>>();
            services.AddTransient<CrudRepository<Entity.UserRole>, CrudRepository<Entity.UserRole>>();
            services.AddTransient<CrudRepository<Entity.ApplicationFeature>, CrudRepository<Entity.ApplicationFeature>>();

            services.AddOptions();
            services.Configure<Config.AppSettingConfig>(Configuration.GetSection("Config"));
            services.Configure<Config.SmtpConfig>(Configuration.GetSection("SmtpConfig"));

            services.AddDbContext<MtsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}

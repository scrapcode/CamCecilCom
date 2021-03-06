﻿using CamCecilCom.Data;
using CamCecilCom.Data.Repository;
using CamCecilCom.Models;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CamCecilCom
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Builds the Configuration object
            string envConfigPath = $"{appEnv.ApplicationBasePath}/appsettings.{env.EnvironmentName}.json";

            var confBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            // Adds a private development config file that is added to
            // the .gitignore so that important strings are not checked
            // into the git repository.
            Debug.Assert(File.Exists(envConfigPath));

            if (File.Exists( envConfigPath ))
            {
                confBuilder.AddJsonFile(envConfigPath);
            }
            
            this.Configuration = confBuilder.Build();

            string connString = Configuration["Data:DefaultConnection:ConnectionString"];
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // MVC 6
            services.AddMvc(config =>
            {
#if !DEBUG
                // Use HTTPS for the entire application.
                config.Filters.Add(new RequireHttpsAttribute());
#endif
            })
            .AddJsonOptions(opt =>
            {
                opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            services.AddIdentity<User, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Password.RequiredLength = 8;
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
                config.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api") &&
                            ctx.Response.StatusCode == (int)HttpStatusCode.OK)
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }
                        else
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                        }

                        return Task.FromResult(0);
                    }
                };
            })
            .AddEntityFrameworkStores<AppDbContext>();

            // EntityFramework 7
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AppDbContext>(options =>
                {
                    // Will use the last Data:DefaultConnection:ConnectionString
                    // that was loaded from the config files in the constructor.
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
                });

            // Injections
            services.AddTransient<AppDbContextSeedData>();
            services.AddScoped<BlogPostRepository>();
            services.AddScoped<IRepository<User, string>, UserRepository>();
        }

        public async void Configure(IApplicationBuilder app, AppDbContextSeedData seeder)
        {
            app.UseStaticFiles();

            app.UseDeveloperExceptionPage();

            app.UseIdentity();

            app.UseMvc(options =>
            {
                options.MapRoute("default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Main", Action = "Index" }
                    );
            });
            
            await seeder.EnsureSeedData();
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

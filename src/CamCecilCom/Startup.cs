using CamCecilCom.Data;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;

namespace CamCecilCom
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Builds the Configuration object
            string envConfigPath = $"appsettings.{env.EnvironmentName}.json";

            var confBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            // Adds a private development config file that is added to
            // the .gitignore so that important strings are not checked
            // into the git repository.
            if (File.Exists( envConfigPath ))
            {
                confBuilder.AddJsonFile(envConfigPath);
            }

            this.Configuration = confBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // MVC 6
            services.AddMvc();

            // EntityFramework 7
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AppDbContext>(options =>
                {
                    // Will use the last Data:DefaultConnection:ConnectionString
                    // that was loaded from the config files in the constructor.
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
                });

            // Dependency Injections
        }

        public void Configure(IApplicationBuilder app)
        {

            app.UseMvc(options =>
            {
                options.MapRoute("default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Main", Action = "Index" }
                    );
            });

            app.UseStaticFiles();
            
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

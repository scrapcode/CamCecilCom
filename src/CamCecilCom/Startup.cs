using CamCecilCom.Data;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace CamCecilCom
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            // Builds the Configuration object
            var confBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json");
            this.Configuration = confBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]);
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSql

            app.UseMvc(options =>
            {
                options.MapRoute("default",
                    template: "{controller}/{action}/{id?}",
                    defaults: "Blog/Index"
                    );
            });
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

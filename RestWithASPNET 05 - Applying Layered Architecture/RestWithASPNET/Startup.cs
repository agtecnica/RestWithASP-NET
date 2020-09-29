using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestWithASPNET.Model.Context;
using Microsoft.EntityFrameworkCore;
using RestWithASPNET.Business;
using RestWithASPNET.Business.Implementattions;
using RestWithASPNET.Repository;
using RestWithASPNET.Repository.Implementattions;

namespace RestWithASPNET
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
            var connection = Configuration["ConnectionStrings:PostgresConnectionString"];//Em appsettings.json
            var con = Configuration.GetConnectionString("PostgresConnectionString");

            services.AddEntityFrameworkNpgsql().AddDbContext<SqlContext>(options => options.UseNpgsql(con));
            services.AddControllers();

            services.AddApiVersioning();

            //Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

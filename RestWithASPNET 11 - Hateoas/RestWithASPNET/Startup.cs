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
using Microsoft.Extensions.Logging;
using System;
using Npgsql;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using RestWithASPNET.Repository.Generic;
using Microsoft.Net.Http.Headers;
using Tapioca.HATEOAS;
using RestWithASPNET.HyperMedia;

namespace RestWithASPNET
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var connection = _configuration["ConnectionStrings:PostgresConnectionString"];//Em appsettings.json
            var connectionString = _configuration.GetConnectionString("PostgresConnectionString");
            services.AddEntityFrameworkNpgsql().AddDbContext<SqlContext>(options => options.UseNpgsql(connectionString));

            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new NpgsqlConnection(connectionString);

                    //var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    var evolve = new Evolve.Evolve(evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "DataBase/Migrations", "DataBase/DataSet" },
                        IsEraseDisabled = true //para não apagar os dados toda vez que executar
                    };
                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("DataBase migration failed.", ex);
                    //throw;
                }
            }

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
                options.EnableEndpointRouting = false;
            })
                .AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptions);

            services.AddControllers();
            services.AddApiVersioning(option => option.ReportApiVersions = true);

            //Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusiness>();
            services.AddScoped<IBookBusiness, BookBusiness>();
            //services.AddScoped<IPersonRepository, PersonRepository>();

            //Dependency Injection of GenerecRepository
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
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
                endpoints.MapControllerRoute("DefaultApi", "{controller=values}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseMvc(routes => {
            //    routes.MapRoute(
            //        name: "DefaultApi",
            //        template: "{controller=Values}/{id?}");
            //});
        }
    }
}

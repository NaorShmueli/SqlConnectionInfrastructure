using EFDAL.DB;
using EFDAL.DB.Entities;
using EFDAL.DB.Repositories;
using EntityFrameworkTemplate.Abstraction.Interfaces;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExample
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureSwagger(services);
            AddHealthChecks(services);
            ConfigureLogs(services);
            ConfigureMetrics(services);

            services.AddControllers().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            services.AddScoped<PersonContext>();
            services.AddScoped<IRepository<EFPerson>, EFPersonRepository>();
            //services.AddTransient<IUnitOfWork, UnitOfWork>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseMetricsAllEndpoints();
            app.UseEndpoints(endpoint => {
                endpoint.MapControllers();
                endpoint.MapHealthChecks("/health", new HealthCheckOptions { ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse });
            });
            EnableSwagger(app);
            //CreateInitialDatabase(loggerFactory);
        }
        public void CreateInitialDatabase(ILoggerFactory loggerFactory)
        {
            using (var context = new PersonContext(Configuration))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //var person = new EFPerson { FirstName = "Naor", LastName = "Shmuelo",PhoneNumbers = new List<EFPhoneNumber> { new EFPhoneNumber { PhoneNumber = "0544535540"} },FriendPhoneNumbers = new List<EFFriendPhoneNumber> { new EFFriendPhoneNumber{ FriendName = "Batel",PhoneNumber = "0507915159"} } };


                //var personRepository = new EFPersonRepository(context, loggerFactory);

                //personRepository.Add(person);

                //personRepository.SaveAsync();
            }
        }

    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using Serilog;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Template.Controllers;
using HealthChecks.UI.Client;
using Microsoft.OpenApi.Models;
using Template.Configs;

namespace Template
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            LogConfig.Configure();

            services.AddControllers()
            .AddFluentValidation(s =>
            {
                s.RegisterValidatorsFromAssemblyContaining<DeveloperValidator>();
                s.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
            });

            services.AddSwaggerGen(opt =>
            opt.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1"
            }));

            services.AddHealthChecks()
                .AddCheck<HealthCheckExample>("HealthCheckExampleGoogleRequest");
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseRouting();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "TemplateSwagger");
                c.RoutePrefix = string.Empty;
            });


            //app.UseSerilogRequestLogging(options =>
            //{
            //       options.EnrichDiagnosticContext = LogConfig.EnrichFromRequest
             
            //});

            ////TODO ?? 
            //app.UseHealthChecks("/hc", new HealthCheckOptions()
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

            });
        }
    }
}

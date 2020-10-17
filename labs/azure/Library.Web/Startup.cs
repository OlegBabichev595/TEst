using Library.Core.Repositories;
using Library.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Library.Web
{
    public class Startup
    {
        public IConfiguration Config { get; }

        public Startup(IConfiguration config)
        {
            Config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<UnitOfWorkOptions>(Config.GetSection("UnitOfWork"));
            services.Configure<AppInfo>(Config.GetSection("AppInfo"));

            services.AddControllersWithViews();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseStatusCodePagesWithReExecute("/error/{0}");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseSession();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
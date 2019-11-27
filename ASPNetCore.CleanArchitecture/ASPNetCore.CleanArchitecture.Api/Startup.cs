/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using ASPNetCore.CleanArchitecture.Setup;
using AutoMapper;
using ASPNetCore.CleanArchitecture.Api.Extensions;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNetCore.CleanArchitecture.Api
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
            services.AddOptions();
            services.AddLocalization();

            var configuration = new MapperConfiguration(cfg =>
                cfg.AddMaps(new[] {
                    "ASPNetCore.CleanArchitecture.API",
                    "ASPNetCore.CleanArchitecture.Infrastructure"
                })
            );
            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAppMVC();
            services.AddAppLogging();
            services.AddAppSwaggerGen();
            services.AddAppDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAppExceptionsMiddleware();
            app.UseRequestLocalization(BuildLocalizationOptions());

            app.UseAppSwagger();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private RequestLocalizationOptions BuildLocalizationOptions()
        {
            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("fr-FR"),
                new CultureInfo("en-US")
            };

            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("fr-FR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            return options;
        }
    }
}

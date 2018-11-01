/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using AutoMapper;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

using ASPNetCore.CleanArchitecture.Api.Extensions;

using ASPNetCore.CleanArchitecture.Setup;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                  .AddJsonOptions(o =>
                  {
                      if (o.SerializerSettings.ContractResolver != null)
                      {
                          var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
                          castedResolver.NamingStrategy = null;
                      }
                  }).AddMvcOptions(o => {
                      o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                  });

            services.AddAutoMapper();

            services.AddSwagger();
            services.AddDependencies();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseMySwaggerConfig();

            app.UseHttpsRedirection();
            app.UseMvc();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStatusCodePages();
            app.UseMvc();

            app.UseHttpsRedirection();
            app.UseMySwaggerConfig();
            app.UseStaticFiles();
        }
    }
}

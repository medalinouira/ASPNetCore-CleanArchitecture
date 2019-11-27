/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.IO;
using System.Reflection;
using NLog.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNetCore.CleanArchitecture.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        #region Methods
        public static IServiceCollection AddAppMVC(this IServiceCollection _iServiceCollection)
        {
            _iServiceCollection.AddControllers()
                  .AddNewtonsoftJson(options =>
                  {
                      options.SerializerSettings.ContractResolver = new DefaultContractResolver();

                  }).AddMvcOptions(options =>
                  {
                      options.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
                  });
            return _iServiceCollection;
        }
        public static IServiceCollection AddAppLogging(this IServiceCollection _iServiceCollection)
        {
            _iServiceCollection.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddNLog();
                loggingBuilder.AddDebug();
                loggingBuilder.AddConsole();
            });

            return _iServiceCollection;
        }
        public static IServiceCollection AddAppSwaggerGen(this IServiceCollection _iServiceCollection)
        {
            _iServiceCollection.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("V2.0.0", new OpenApiInfo
                {
                    Version = "V2.0.0",
                    Title = "ASP.NET Core 3 API Clean Architecture",
                    Description = "A sample RESTFul ASP.NET Core 3 API",
                    Contact = new OpenApiContact
                    {
                        Name = "Mohamed Ali NOUIRA",
                        Email = "support@mohamedalinouira.com",
                        Url = new Uri("https://www.mohamedalinouira.com")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"

                });

                var security = new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()

                    }
                };
                c.AddSecurityRequirement(security);

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return _iServiceCollection;
        }
        #endregion
    }
}

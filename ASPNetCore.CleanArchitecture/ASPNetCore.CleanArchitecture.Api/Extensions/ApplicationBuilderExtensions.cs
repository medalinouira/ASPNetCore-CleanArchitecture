/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using ASPNetCore.CleanArchitecture.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ASPNetCore.CleanArchitecture.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        #region Methods
        public static IApplicationBuilder UseAppSwagger(this IApplicationBuilder _iApplicationBuilder)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            _iApplicationBuilder.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            _iApplicationBuilder.UseSwaggerUI(c =>
            {
                c.EnableFilter();
                c.ShowExtensions();
                c.EnableValidator();
                c.EnableDeepLinking();
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.RoutePrefix = string.Empty;
                c.DefaultModelExpandDepth(2);
                c.DefaultModelsExpandDepth(-1);
                c.DocExpansion(DocExpansion.None);
                c.DefaultModelRendering(ModelRendering.Model);
                c.SwaggerEndpoint("/swagger/V2.0.0/swagger.json", "ASP.NET Core API Template V2.0.0");
            });

            return _iApplicationBuilder;
        }
        public static IApplicationBuilder UseAppExceptionsMiddleware(this IApplicationBuilder _iApplicationBuilder)
        {
            _iApplicationBuilder.UseMiddleware<AppExceptionsMiddleware>();
            return _iApplicationBuilder;
        }
        #endregion
    }
}

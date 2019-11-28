/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using ASPNetCore.CleanArchitecture.Resources;
using ASPNetCore.CleanArchitecture.Exceptions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;

namespace ASPNetCore.CleanArchitecture.Api.Middlewares
{
    public class AppExceptionsMiddleware
    {
        #region Fields
        private readonly RequestDelegate _requestDelegate;

        private readonly string _contentType = "application/json";

        private readonly ILogger<AppExceptionsMiddleware> _iLogger;    
        private readonly IStringLocalizer<AppResources> _iStringLocalizer;
        #endregion

        #region Constructor    
        public AppExceptionsMiddleware(
            RequestDelegate _requestDelegate,
            ILogger<AppExceptionsMiddleware> _iLogger,
            IStringLocalizer<AppResources> _iStringLocalizer
            )
        {
            this._iLogger = _iLogger;
            this._requestDelegate = _requestDelegate;
            this._iStringLocalizer = _iStringLocalizer;
        }
        #endregion

        #region Methods
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _requestDelegate(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var exDetails = CreateException(ex);
            int.TryParse(exDetails.Code.ToString().Substring(0, 3), out var statusCode);

            context.Response.StatusCode = statusCode;
            context.Response.ContentType = _contentType;

            _iLogger.LogError(exDetails.Code, ex, exDetails.ToString());

            await context.Response.WriteAsync(exDetails.ToString());
        }
        private ExceptionDetails CreateException(Exception ex)
        {
            var parseSucceded = int.TryParse(ex.Message, out int code);
            int exCode = parseSucceded ? code : (int)ExceptionsCodes.UnknownCodeException;
            var exDetails = new ExceptionDetails
            {                
                Code = exCode,
                Message = _iStringLocalizer["RSX_EXCEPTION_" + exCode.ToString()]
            };

            return exDetails;
        }
        #endregion
    }
}

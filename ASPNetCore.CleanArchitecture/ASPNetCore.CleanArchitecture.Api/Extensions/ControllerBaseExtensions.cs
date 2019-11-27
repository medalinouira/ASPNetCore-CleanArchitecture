/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.CleanArchitecture.Api.Extensions
{
    public static class ControllerBaseExtensions
    {
        #region Methods
        public static string GetActionName(this ControllerBase baseController)
        {
            var routeDateValues = baseController.RouteData.Values;
            if (routeDateValues.ContainsKey("action"))
            {
                return (string)routeDateValues["action"];
            }
            return string.Empty;
        }
        public static string GetControllerName(this ControllerBase baseController)
        {
            var routeDateValues = baseController.RouteData.Values;
            if (routeDateValues.ContainsKey("controller"))
            {
                return (string)routeDateValues["controller"];
            }
            return string.Empty;
        }
        #endregion
    }
}

/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.CleanArchitecture.Api.Controllers.QueriesParams.BaseQueryParams
{
    public interface ISearchQueryParams
    {
        [FromQuery]
        public string Term { get; set; }
        [FromQuery]
        public string SearchBy { get; set; }
    }
}

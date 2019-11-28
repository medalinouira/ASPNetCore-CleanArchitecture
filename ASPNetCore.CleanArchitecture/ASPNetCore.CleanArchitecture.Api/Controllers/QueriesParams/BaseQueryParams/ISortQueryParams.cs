/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using Microsoft.AspNetCore.Mvc;

namespace ASPNetCore.CleanArchitecture.Api.Controllers.QueriesParams.BaseQueryParams
{
    public interface ISortQueryParams
    {
        [FromQuery]
        public string SortBy {get; set;}
        [FromQuery]
        public ISortOrder SortOrder { get; set; }
    }
}

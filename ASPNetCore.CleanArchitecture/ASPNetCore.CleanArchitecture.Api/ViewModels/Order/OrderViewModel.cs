/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;

namespace ASPNetCore.CleanArchitecture.Api.ViewModels.Order
{
    public class OrderViewModel
    {
        /// <summary>
        /// Gets or sets the order's id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the order's date.
        /// </summary>
        public DateTime Date { get; set; }
    }
}

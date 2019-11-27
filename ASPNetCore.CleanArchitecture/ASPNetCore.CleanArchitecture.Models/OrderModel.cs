/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using ASPNetCore.CleanArchitecture.Models.Attributs;

namespace ASPNetCore.CleanArchitecture.Models
{
    [EntityName(Entity: "Order")]
    public class OrderModel
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

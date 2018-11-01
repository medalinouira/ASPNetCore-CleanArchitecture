/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNetCore.CleanArchitecture.Data.Entities
{
    public class Order
    {
        /// <summary>
        /// Gets or sets the order's id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the order's date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the order's customer.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Many to Many between Order and Product.
        /// </summary>
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

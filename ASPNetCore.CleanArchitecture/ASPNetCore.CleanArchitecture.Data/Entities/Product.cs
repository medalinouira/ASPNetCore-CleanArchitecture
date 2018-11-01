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
    public class Product
    {
        /// <summary>
        /// Gets or sets the product's id.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the product's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product's price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the product's price unit.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Many to Many between Order and Product.
        /// </summary>
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Linq;
using ASPNetCore.CleanArchitecture.Data.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCore.CleanArchitecture.Data.Database
{
    public class FakeDbContext : BaseDbContext
    {
        #region Constructor
        public FakeDbContext(DbContextOptions options) : base(options)
        {
            SeedFakeData();
        }
        #endregion

        #region Methods
        public void SeedFakeData()
        {
            //Mock Products
            Products.Add(new Product { Id = Guid.NewGuid(), Name = "Product 1", Price = 323, Unit = "euro" });
            Products.Add(new Product { Id = Guid.NewGuid(), Name = "Product 2", Price = 400, Unit = "euro" });
            Products.Add(new Product { Id = Guid.NewGuid(), Name = "Product 3", Price = 234, Unit = "euro" });
            Products.Add(new Product { Id = Guid.NewGuid(), Name = "Product 4", Price = 120, Unit = "euro" });
            Products.Add(new Product { Id = Guid.NewGuid(), Name = "Product 5", Price = 850, Unit = "euro" });
            Products.Add(new Product { Id = Guid.NewGuid(), Name = "Product 6", Price = 43, Unit = "euro" });
            Products.Add(new Product { Id = Guid.NewGuid(), Name = "Product 7", Price = 165, Unit = "euro" });
            Products.Add(new Product { Id = Guid.NewGuid(), Name = "Product 8", Price = 549, Unit = "euro" });
            SaveChanges();

            //Mock Orders
            Orders.Add(new Order { Id = Guid.NewGuid(), Date = DateTime.Now.AddDays(-5) });
            Orders.Add(new Order { Id = Guid.NewGuid(), Date = DateTime.Now.AddDays(-10) });
            Orders.Add(new Order { Id = Guid.NewGuid(), Date = DateTime.Now.AddDays(-12) });
            Orders.Add(new Order { Id = Guid.NewGuid(), Date = DateTime.Now.AddDays(-11) });
            Orders.Add(new Order { Id = Guid.NewGuid(), Date = DateTime.Now.AddDays(-2) });
            Orders.Add(new Order { Id = Guid.NewGuid(), Date = DateTime.Now.AddDays(-19) });
            Orders.Add(new Order { Id = Guid.NewGuid(), Date = DateTime.Now.AddDays(-1) });
            Orders.Add(new Order { Id = Guid.NewGuid(), Date = DateTime.Now.AddDays(-15) });
            SaveChanges();

            //Mock OrderProducts
            OrderProduct orderProduct1 = new OrderProduct() { Order = Orders.ToList()[0], Product = Products.ToList()[0] };
            OrderProduct orderProduct2 = new OrderProduct() { Order = Orders.ToList()[0], Product = Products.ToList()[1] };
            OrderProduct orderProduct3 = new OrderProduct() { Order = Orders.ToList()[0], Product = Products.ToList()[2] };

            OrderProduct orderProduct4 = new OrderProduct() { Order = Orders.ToList()[1], Product = Products.ToList()[3] };
            OrderProduct orderProduct5 = new OrderProduct() { Order = Orders.ToList()[1], Product = Products.ToList()[4] };

            OrderProduct orderProduct6 = new OrderProduct() { Order = Orders.ToList()[2], Product = Products.ToList()[5] };

            OrderProduct orderProduct7 = new OrderProduct() { Order = Orders.ToList()[3], Product = Products.ToList()[6] };

            OrderProduct orderProduct8 = new OrderProduct() { Order = Orders.ToList()[4], Product = Products.ToList()[7] };

            OrderProduct orderProduct9 = new OrderProduct() { Order = Orders.ToList()[5], Product = Products.ToList()[5] };

            OrderProduct orderProduct10 = new OrderProduct() { Order = Orders.ToList()[6], Product = Products.ToList()[2] };

            OrderProduct orderProduct11 = new OrderProduct() { Order = Orders.ToList()[7], Product = Products.ToList()[6] };
            SaveChanges();

            //Mock Customers
            Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "FirstName 1", LastName = "LastName 1", Email = "email1@email.com", Company = "Company 1", Phone = "06 XX XX XX XX", Orders = new List<Order>() { } });
            Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "FirstName 2", LastName = "LastName 2", Email = "email2@email.com", Company = "Company 2", Phone = "07 XX XX XX XX", Orders = new List<Order>() { Orders.ToList()[0], Orders.ToList()[1], Orders.ToList()[2] } });
            Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "FirstName 3", LastName = "LastName 3", Email = "email3@email.com", Company = "Company 3", Phone = "08 XX XX XX XX", Orders = new List<Order>() { Orders.ToList()[3], Orders.ToList()[4], Orders.ToList()[5] } });
            Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "FirstName 4", LastName = "LastName 4", Email = "email4@email.com", Company = "Company 4", Phone = "09 XX XX XX XX", Orders = new List<Order>() { Orders.ToList()[6], Orders.ToList()[7] } });
            SaveChanges();
        }
        #endregion
    }
}

/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ASPNetCore.CleanArchitecture.Data.Database;
using ASPNetCore.CleanArchitecture.Domain.Services;
using ASPNetCore.CleanArchitecture.Interfaces.IServices;
using ASPNetCore.CleanArchitecture.Interfaces.IRepositories;
using ASPNetCore.CleanArchitecture.Infrastructure.Repositories;

namespace ASPNetCore.CleanArchitecture.Setup
{
    public static class StartupExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection _iServiceCollection)
        {
            #region Data
            _iServiceCollection.AddDbContext<BaseDbContext, FakeDbContext>(opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            #endregion

            #region Services
            _iServiceCollection.AddTransient<IOrderService, OrderService>();
            _iServiceCollection.AddTransient<IProductService, ProductService>();
            _iServiceCollection.AddTransient<ICustomerService, CustomerService>();
            #endregion

            #region AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles("ASPNetCore.CleanArchitecture" + ".Api", "ASPNetCore.CleanArchitecture" + ".Infrastructure");
            });
            #endregion

            #region Repositories
            _iServiceCollection.AddTransient<IOrderRepository, OrderRepository>();
            _iServiceCollection.AddTransient<IProductRepository, ProductRepository>();
            _iServiceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
            #endregion

            return _iServiceCollection;
        }
    }
}

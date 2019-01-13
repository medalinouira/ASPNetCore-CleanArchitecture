/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using CleanArchitecture1.Data.Database;
using CleanArchitecture1.Domain.Services;
using CleanArchitecture1.Interfaces.IServices;
using CleanArchitecture1.Interfaces.IRepositories;
using CleanArchitecture1.Infrastructure.Repositories;

namespace CleanArchitecture1.Setup
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
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles("CleanArchitecture1" + ".Api", "CleanArchitecture1" + ".Infrastructure");
            });

            IMapper mapper = mappingConfig.CreateMapper();
            _iServiceCollection.AddSingleton(mapper);
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

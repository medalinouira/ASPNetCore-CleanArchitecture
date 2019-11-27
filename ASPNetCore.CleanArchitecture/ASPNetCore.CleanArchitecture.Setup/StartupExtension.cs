/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using ASPNetCore.CleanArchitecture.Data.Database;
using ASPNetCore.CleanArchitecture.Domain.Services;
using ASPNetCore.CleanArchitecture.Interfaces.IServices;
using ASPNetCore.CleanArchitecture.Interfaces.IRepositories;
using ASPNetCore.CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ASPNetCore.CleanArchitecture.Setup
{
    public static class StartupExtension
    {
        #region Methods
        public static IServiceCollection AddAppDependencies(this IServiceCollection _iServiceCollection)
        {
            #region Data
            _iServiceCollection.AddDbContext<BaseDbContext, FakeDbContext>(opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()));
            #endregion

            #region Services       
            _iServiceCollection.AddIInjectableDependencies(typeof(OrderService));
            _iServiceCollection.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            #endregion

            #region Repositories
            _iServiceCollection.AddIInjectableDependencies(typeof(OrderRepository));
            _iServiceCollection.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            _iServiceCollection.AddTransient(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
            #endregion

            return _iServiceCollection;
        }
        #endregion
    }
}

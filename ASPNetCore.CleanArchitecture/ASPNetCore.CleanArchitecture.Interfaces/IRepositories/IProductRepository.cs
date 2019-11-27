/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using ASPNetCore.CleanArchitecture.Models;

namespace ASPNetCore.CleanArchitecture.Interfaces.IRepositories
{
    public interface IProductRepository : IBaseRepository<ProductModel>, IInjectable
    {
    }
}

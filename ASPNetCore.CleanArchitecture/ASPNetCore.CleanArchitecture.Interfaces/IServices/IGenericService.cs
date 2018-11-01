/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.CleanArchitecture.Interfaces.IServices
{
    public interface IGenericService<TModel> where TModel : class
    {
        Task DeleteById(Guid id);
        Task Insert(TModel model);
        Task Update(TModel model);
        Task Delete(TModel model);
        IQueryable<TModel> GetAll();
        Task<TModel> GetById(Guid id);
    }
}

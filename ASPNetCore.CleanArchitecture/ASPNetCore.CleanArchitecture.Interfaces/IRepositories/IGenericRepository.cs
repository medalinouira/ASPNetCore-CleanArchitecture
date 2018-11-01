/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.CleanArchitecture.Interfaces.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task DeleteById(Guid id);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetById(Guid id);
        Task Insert(TEntity entityToInsert);
        Task Update(TEntity entityToUpdate);
        Task Delete(TEntity entityToDelete);
    }
}

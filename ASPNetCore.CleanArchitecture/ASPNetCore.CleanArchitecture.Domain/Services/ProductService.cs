/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Linq;
using System.Threading.Tasks;

using ASPNetCore.CleanArchitecture.Models;
using ASPNetCore.CleanArchitecture.Interfaces.IServices;
using ASPNetCore.CleanArchitecture.Interfaces.IRepositories;

namespace ASPNetCore.CleanArchitecture.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _iProductRepository;

        public ProductService(IProductRepository _iProductRepository)
        {
            this._iProductRepository = _iProductRepository;
        }        

        public async Task DeleteById(Guid id)
        {
            await this._iProductRepository.DeleteById(id);
        }

        public IQueryable<ProductModel> GetAll()
        {
            return this._iProductRepository.GetAll();
        }

        public async Task Delete(ProductModel model)
        {
            await this._iProductRepository.Delete(model);
        }

        public async Task Insert(ProductModel model)
        {
            await this._iProductRepository.Insert(model);
        }

        public async Task Update(ProductModel model)
        {
            await this._iProductRepository.Update(model);
        }

        public async Task<ProductModel> GetById(Guid id)
        {
            return await this._iProductRepository.GetById(id);
        }
    }
}

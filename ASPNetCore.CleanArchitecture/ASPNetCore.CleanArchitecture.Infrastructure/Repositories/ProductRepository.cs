/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using ASPNetCore.CleanArchitecture.Models;
using ASPNetCore.CleanArchitecture.Data.Entities;
using ASPNetCore.CleanArchitecture.Data.Database;
using ASPNetCore.CleanArchitecture.Interfaces.IRepositories;

namespace ASPNetCore.CleanArchitecture.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        public ProductRepository(BaseDbContext _baseDbContext, IMapper _iMapper) : base(_baseDbContext, _iMapper)
        {
        }

        public async Task DeleteById(Guid id)
        {
            try
            {
                var product = await _baseDbContext.Products.FindAsync(id);
                if (product != null)
                {
                    _baseDbContext.Products.Remove(product);
                    await _baseDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<ProductModel> GetAll()
        {
            try
            {
                var products = _baseDbContext.Products;
                return products != null ? (_iMapper.Map<IList<Product>, IList<ProductModel>>(products.ToList())).AsQueryable() : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ProductModel> GetById(Guid id)
        {
            try
            {
                var product = await _baseDbContext.Products.FindAsync(id);
                return product != null ? _iMapper.Map<Product, ProductModel>(product) : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(ProductModel entityToDelete)
        {
            try
            {
                if (entityToDelete == null)
                    return;

                var product = await _baseDbContext.Products.FindAsync(entityToDelete.Id);
                if (product != null)
                {
                    _baseDbContext.Products.Remove(product);
                    await _baseDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(ProductModel entityToInsert)
        {
            try
            {
                if (entityToInsert == null)
                    return;

                var product = _iMapper.Map<ProductModel, Product>(entityToInsert);
                if (product == null)
                    return;

                await _baseDbContext.Products.AddAsync(product);
                await _baseDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(ProductModel entityToUpdate)
        {
            try
            {
                if (entityToUpdate == null)
                    return;

                var product = _iMapper.Map<ProductModel, Product>(entityToUpdate);
                if (product == null)
                    return;

                _baseDbContext.Products.Update(product);
                await _baseDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

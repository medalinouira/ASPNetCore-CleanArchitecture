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
    public class CustomerRepository : BaseRepository , ICustomerRepository
    {
        public CustomerRepository(BaseDbContext _baseDbContext, IMapper _iMapper) : base(_baseDbContext, _iMapper)
        {
        }

        public async Task DeleteById(Guid id)
        {
            try
            {
                var customer = await _baseDbContext.Customers.FindAsync(id);
                if (customer != null)
                {
                    _baseDbContext.Customers.Remove(customer);
                    await _baseDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<CustomerModel> GetAll()
        {
            try
            {
                var customers = _baseDbContext.Customers;
                return customers != null ? (_iMapper.Map<IList<Customer>, IList<CustomerModel>>(customers.ToList())).AsQueryable() : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CustomerModel> GetById(Guid id)
        {
            try
            {
                var customer = await _baseDbContext.Customers.FindAsync(id);
                return customer != null ? _iMapper.Map<Customer, CustomerModel>(customer) : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(CustomerModel entityToDelete)
        {
            try
            {
                if (entityToDelete == null)
                    return;

                var customer = await _baseDbContext.Customers.FindAsync(entityToDelete.Id);
                if (customer != null)
                {
                    _baseDbContext.Customers.Remove(customer);
                    await _baseDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(CustomerModel entityToInsert)
        {
            try
            {
                if (entityToInsert == null)
                    return;

                var customer = _iMapper.Map<CustomerModel, Customer>(entityToInsert);
                if (customer == null)
                    return;

                await _baseDbContext.Customers.AddAsync(customer);
                await _baseDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(CustomerModel entityToUpdate)
        {
            try
            {
                if (entityToUpdate == null)
                    return;

                var customer = _iMapper.Map<CustomerModel, Customer>(entityToUpdate);
                if (customer == null)
                    return;

                _baseDbContext.Customers.Update(customer);
                await _baseDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

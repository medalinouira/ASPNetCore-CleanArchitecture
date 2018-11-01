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
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(BaseDbContext _iBaseDbContext, IMapper _iMapper) : base(_iBaseDbContext, _iMapper)
        {
        }

        public async Task DeleteById(Guid id)
        {
            try
            {
                var order = await _baseDbContext.Orders.FindAsync(id);
                if (order != null)
                {
                    _baseDbContext.Remove(order);
                    await _baseDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<OrderModel> GetAll()
        {
            try
            {
                var orders = _baseDbContext.Orders;
                return orders != null ? (_iMapper.Map<IList<Order>, IList<OrderModel>>(orders.ToList())).AsQueryable() : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderModel> GetById(Guid id)
        {
            try
            {
                var order = await _baseDbContext.Orders.FindAsync(id);
                return order != null ? _iMapper.Map<Order, OrderModel>(order) : null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(OrderModel entityToDelete)
        {
            try
            {
                if (entityToDelete == null)
                    return;

                var order = await _baseDbContext.Orders.FindAsync(entityToDelete.Id);
                if (order != null)
                {
                    _baseDbContext.Orders.Remove(order);
                    await _baseDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(OrderModel entityToInsert)
        {
            try
            {
                if (entityToInsert == null)
                    return;

                var order = _iMapper.Map<OrderModel, Order>(entityToInsert);
                if (order == null)
                    return;

                await _baseDbContext.Orders.AddAsync(order);
                await _baseDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(OrderModel entityToUpdate)
        {
            try
            {
                if (entityToUpdate == null)
                    return;

                var order = _iMapper.Map<OrderModel, Order>(entityToUpdate);
                if (order == null)
                    return;

                _baseDbContext.Orders.Update(order);
                await _baseDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

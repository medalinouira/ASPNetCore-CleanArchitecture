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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _iOrderRepository;

        public OrderService(IOrderRepository _iOrderRepository)
        {
            this._iOrderRepository = _iOrderRepository;
        }

        public async Task DeleteById(Guid id)
        {
            await _iOrderRepository.DeleteById(id);
        }

        public IQueryable<OrderModel> GetAll()
        {
            return _iOrderRepository.GetAll();
        }

        public async Task Delete(OrderModel model)
        {
            await _iOrderRepository.Delete(model);
        }

        public async Task Insert(OrderModel model)
        {
            await _iOrderRepository.Insert(model);
        }

        public async Task Update(OrderModel model)
        {
            await _iOrderRepository.Update(model);
        }

        public async Task<OrderModel> GetById(Guid id)
        {
            return await _iOrderRepository.GetById(id);
        }
    }
}

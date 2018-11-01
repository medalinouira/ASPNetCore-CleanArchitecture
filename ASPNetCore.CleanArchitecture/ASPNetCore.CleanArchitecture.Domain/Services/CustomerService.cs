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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _iCustomerRepository;

        public CustomerService(ICustomerRepository _iCustomerRepository)
        {
            this._iCustomerRepository = _iCustomerRepository;
        }    

        public async Task DeleteById(Guid id)
        {
            await _iCustomerRepository.DeleteById(id);
        }

        public IQueryable<CustomerModel> GetAll()
        {
            return _iCustomerRepository.GetAll();
        }

        public async Task Delete(CustomerModel model)
        {
            await _iCustomerRepository.Delete(model);
        }

        public async Task Insert(CustomerModel model)
        {
            await _iCustomerRepository.Insert(model);
        }

        public async Task Update(CustomerModel model)
        {
            await _iCustomerRepository.Update(model);
        }

        public async Task<CustomerModel> GetById(Guid id)
        {
            return await _iCustomerRepository.GetById(id);
        }
    }
}

/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using ASPNetCore.CleanArchitecture.Models;
using ASPNetCore.CleanArchitecture.Interfaces.IServices;
using ASPNetCore.CleanArchitecture.Interfaces.IRepositories;

namespace ASPNetCore.CleanArchitecture.Domain.Services
{
    public class CustomerService : BaseService<CustomerModel>, ICustomerService
    {
        #region Fields
        private readonly ICustomerRepository _iCustomerRepository;
        #endregion

        #region Constructor
        public CustomerService(ICustomerRepository _iCustomerRepository,
                               IBaseRepository<CustomerModel> _ibaseRepository) : base(_ibaseRepository)
        {
            this._iCustomerRepository = _iCustomerRepository;
        }
        #endregion

        #region Methods
        #endregion
    }
}

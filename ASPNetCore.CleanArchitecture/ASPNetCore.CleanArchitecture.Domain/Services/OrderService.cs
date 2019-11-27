/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using ASPNetCore.CleanArchitecture.Models;
using ASPNetCore.CleanArchitecture.Interfaces.IServices;
using ASPNetCore.CleanArchitecture.Interfaces.IRepositories;

namespace ASPNetCore.CleanArchitecture.Domain.Services
{
    public class OrderService : BaseService<OrderModel>, IOrderService
    {
        #region Fields
        private readonly IOrderRepository _iOrderRepository;
        #endregion

        #region Constructor
        public OrderService(IOrderRepository _iOrderRepository,
                            IBaseRepository<OrderModel> _ibaseRepository) : base(_ibaseRepository)
        {
            this._iOrderRepository = _iOrderRepository;
        }
        #endregion

        #region Methods
        #endregion
    }
}

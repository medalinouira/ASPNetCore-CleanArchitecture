/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using ASPNetCore.CleanArchitecture.Models;
using ASPNetCore.CleanArchitecture.Interfaces.IServices;
using ASPNetCore.CleanArchitecture.Interfaces.IRepositories;

namespace ASPNetCore.CleanArchitecture.Domain.Services
{
    public class ProductService : BaseService<ProductModel>, IProductService
    {
        #region Fields
        private readonly IProductRepository _iProductRepository;
        #endregion

        #region Constructor
        public ProductService(IProductRepository _iProductRepository,
                              IBaseRepository<ProductModel> _ibaseRepository) : base(_ibaseRepository)
        {
            this._iProductRepository = _iProductRepository;
        }
        #endregion

        #region Methods
        #endregion
    }
}

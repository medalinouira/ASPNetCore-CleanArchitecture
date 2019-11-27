/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using ASPNetCore.CleanArchitecture.Models;
using AutoMapper;
using ASPNetCore.CleanArchitecture.Data.Database;
using ASPNetCore.CleanArchitecture.Interfaces.IRepositories;

namespace ASPNetCore.CleanArchitecture.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<ProductModel>, IProductRepository
    {
        #region Fields
        private readonly IMapper _iMapper;
        private readonly BaseDbContext _dbContext;
        #endregion

        #region Constructor
        public ProductRepository(IMapper _iMapper,
            BaseDbContext _dbContext) : base(_iMapper, _dbContext)
        {
            this._iMapper = _iMapper;
            this._dbContext = _dbContext;
        }
        #endregion
    }
}

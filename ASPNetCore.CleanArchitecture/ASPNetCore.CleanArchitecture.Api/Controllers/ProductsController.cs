/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using ASPNetCore.CleanArchitecture.Models;
using System.Linq;
using ASPNetCore.CleanArchitecture.Api.Filters;
using ASPNetCore.CleanArchitecture.Api.Extensions;
using ASPNetCore.CleanArchitecture.Interfaces.IServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Swagger.ASPNetCore.CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        #region Fields
        private readonly IProductService _iProductService;
        private readonly ILogger<ProductsController> _iLogger;
        #endregion

        #region Constructor
        public ProductsController(IProductService _iProductService,
                                  ILogger<ProductsController> _iLogger)
        {
            this._iLogger = _iLogger;
            this._iProductService = _iProductService;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Get all products.
        /// </summary>
        // GET: api/products
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            var products = await _iProductService.GetAllAsync();
            if (products != null && products.Count() > 0)
            {
                return Ok(products);
            }
            return NoContent();
        }

        /// <summary>
        /// Get product by id.
        /// </summary>
        // GET api/products
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(Guid id)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            var product = await _iProductService.GetByIdAsync(id);
            if (product == null)
            {
                _iLogger.LogInformation($"Product with {id} wasn't found");
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// Add a new product.
        /// </summary>
        // POST api/products
        [HttpPost]
        [ValidateModelSate]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody]ProductModel productModel)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            var createdProduct = await _iProductService.AddAsync(productModel);

            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct.Id);
        }

        /// <summary>
        /// Put a product.
        /// </summary>
        // PUT api/products/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpPut("{id}")]
        [ValidateModelSate]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(Guid id, [FromBody]ProductModel productModel)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            if (!(await ProductExists(id)))
            {
                return NotFound();
            };

            _iProductService.Update(productModel);

            return NoContent();
        }

        /// <summary>
        /// Delete product by id.
        /// </summary>
        // DELETE api/products/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(Guid id)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            if (!(await ProductExists(id)))
            {
                return NotFound();
            }

            _iProductService.DeleteById(id);

            return NoContent();
        }

        private async Task<bool> ProductExists(Guid id)
        {
            return (await _iProductService.GetAllAsync()).Any(a => a.Id.Equals(id));
        }
        #endregion
    }
}

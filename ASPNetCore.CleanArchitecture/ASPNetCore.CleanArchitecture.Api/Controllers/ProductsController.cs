/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using ASPNetCore.CleanArchitecture.Models;
using ASPNetCore.CleanArchitecture.Interfaces.IServices;

namespace ASPNetCore.CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductService _iProductService;
        private readonly ILogger<ProductsController> _iLogger;

        public ProductsController(IProductService _iProductService,
                                  ILogger<ProductsController> _iLogger)
        {
            this._iLogger = _iLogger;
            this._iProductService = _iProductService;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        // GET: api/products
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_iProductService.GetAll());
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while getting products", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        /// <summary>
        /// Get product by id.
        /// </summary>
        // GET api/products
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var product = await _iProductService.GetById(id);
                if (product == null)
                {
                    _iLogger.LogInformation($"Product with {id} wasn't found");
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while getting product with id {id}", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        /// <summary>
        /// Add a new product.
        /// </summary>
        // POST api/products
        [HttpPost(Name = "AddProduct")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody]ProductModel productModel)
        {
            try
            {
                if (productModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _iProductService.Insert(productModel);

                return CreatedAtRoute("AddProduct", productModel);
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while adding a new product", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        /// <summary>
        /// Put a product.
        /// </summary>
        // PUT api/products/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(Guid id, [FromBody]ProductModel productModel)
        {
            try
            {
                if (productModel == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var product = await _iProductService.GetById(id);
                if (product != null)
                {
                    return NotFound();
                };

                await _iProductService.Update(product);

                return NoContent();
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while puting a Product", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        /// <summary>
        /// Delete product by id.
        /// </summary>
        // DELETE api/products/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var product = await _iProductService.GetById(id);
                if (product != null)
                {
                    return NotFound();
                }

                await _iProductService.Delete(product);

                return NoContent();
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while deleting a product", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        private bool ProductExists(Guid id)
        {
            return _iProductService.GetAll().Any(a => a.Id.Equals(id));
        }
    }
}

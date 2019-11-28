/// Mohamed Ali NOUIRA
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using ASPNetCore.CleanArchitecture.Models;
using System;
using System.Linq;
using ASPNetCore.CleanArchitecture.Api.Filters;
using ASPNetCore.CleanArchitecture.Api.Extensions;
using ASPNetCore.CleanArchitecture.Interfaces.IServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ASPNetCore.CleanArchitecture.Api.Controllers
{
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CustomersController : Controller
    {
        #region Fields
        private readonly ICustomerService _iCustomerService;
        private readonly ILogger<CustomersController> _iLogger;
        #endregion

        #region Constructor
        public CustomersController(ICustomerService _iCustomerService,
                                   ILogger<CustomersController> _iLogger)
        {
            this._iLogger = _iLogger;
            this._iCustomerService = _iCustomerService;
        }
        #endregion

        #region Actions

        #region CRUD
        /// <summary>
        /// Get all customers.
        /// </summary>
        // GET: api/customers
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            var customers = await _iCustomerService.GetAllAsync();
            if (customers != null && customers.Count() > 0)
            {
                return Ok(customers);
            }
            return NoContent();
        }

        /// <summary>
        /// Get customer by id.
        /// </summary>
        // GET api/customers
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(Guid id)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            var customer = await _iCustomerService.GetByIdAsync(id);
            if (customer == null)
            {
                _iLogger.LogInformation($"Customer with {id} wasn't found");
                return NotFound();
            }
            return Ok(customer);
        }

        /// <summary>
        /// Add a new customer.
        /// </summary>
        // POST api/customers
        [HttpPost]
        [ValidateModelSate]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody]CustomerModel customerModel)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            var createdCustomer = await _iCustomerService.AddAsync(customerModel);

            return CreatedAtAction(nameof(GetById), new { id = createdCustomer.Id }, createdCustomer.Id);
        }

        /// <summary>
        /// Put a customer.
        /// </summary>
        // PUT api/customers/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpPut("{id}")]
        [ValidateModelSate]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(Guid id, [FromBody]CustomerModel customerModel)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            if (!(await CustomerExists(id)))
            {
                return NotFound();
            }

            _iCustomerService.Update(customerModel);

            return NoContent();
        }

        /// <summary>
        /// Delete customer by id.
        /// </summary>
        // DELETE api/customers/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(Guid id)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            if (!(await CustomerExists(id)))
            {
                return NotFound();
            }

            _iCustomerService.DeleteById(id);

            return NoContent();
        }

        private async Task<bool> CustomerExists(Guid id)
        {
            return (await _iCustomerService.GetAllAsync()).Any(a => a.Id.Equals(id));
        }
        #endregion

        #region GLOBAL
        #endregion

        #endregion
    }
}

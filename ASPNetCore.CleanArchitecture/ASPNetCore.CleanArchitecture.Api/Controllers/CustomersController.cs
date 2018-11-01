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
    public class CustomersController : Controller
    {
        private readonly ICustomerService _iCustomerService;
        private readonly ILogger<CustomersController> _iLogger;

        public CustomersController(ICustomerService _iCustomerService,
                                   ILogger<CustomersController> _iLogger)
        {
            this._iLogger = _iLogger;
            this._iCustomerService = _iCustomerService;
        }

        /// <summary>
        /// Get all customers.
        /// </summary>
        // GET: api/customers
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_iCustomerService.GetAll());
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while getting customers", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        /// <summary>
        /// Get customer by id.
        /// </summary>
        // GET api/customers
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var customer = await _iCustomerService.GetById(id);
                if (customer == null)
                {
                    _iLogger.LogInformation($"Customer with {id} wasn't found");
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while getting customer with id {id}", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        /// <summary>
        /// Add a new customer.
        /// </summary>
        // POST api/customers
        [HttpPost(Name = "AddCustomer")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]    
        public async Task<IActionResult> Post([FromBody]CustomerModel customerModel)
        {
            try
            {
                if (customerModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _iCustomerService.Insert(customerModel);

                return CreatedAtRoute("AddCustomer", customerModel);
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while adding a new customer", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        /// <summary>
        /// Put a customer.
        /// </summary>
        // PUT api/customers/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(Guid id, [FromBody]CustomerModel customerModel)
        {
            try
            {
                if (customerModel == null)
                {
                    return BadRequest();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var customer = await _iCustomerService.GetById(id);
                if (customer != null)
                {
                    return NotFound();
                }

                await _iCustomerService.Update(customer);

                return NoContent();
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while puting a customer", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }
        
        /// <summary>
        /// Delete customer by id.
        /// </summary>
        // DELETE api/customers/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var customer = await _iCustomerService.GetById(id);
                if (customer != null)
                {
                    return NotFound();
                }

                await _iCustomerService.Delete(customer);

                return NoContent();
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while deleting a customer", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        private bool CustomerExists(Guid id)
        {
            return _iCustomerService.GetAll().Any(a => a.Id.Equals(id));
        }
    }
}

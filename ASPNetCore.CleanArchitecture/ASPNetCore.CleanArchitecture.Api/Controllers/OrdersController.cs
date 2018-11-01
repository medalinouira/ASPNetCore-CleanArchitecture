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
    public class OrdersController : Controller
    {
        private readonly IOrderService _iOrderService;
        private readonly ILogger<OrdersController> _iLogger;

        public OrdersController(IOrderService _iOrderService,
                               ILogger<OrdersController> _iLogger)
        {
            this._iLogger = _iLogger;
            this._iOrderService = _iOrderService;
        }

        /// <summary>
        /// Get all orders.
        /// </summary>
        // GET: api/orders
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_iOrderService.GetAll());
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while getting orders", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        /// <summary>
        /// Get order by id.
        /// </summary>
        // GET api/orders
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var order = await _iOrderService.GetById(id);
                if (order == null)
                {
                    _iLogger.LogInformation($"Order with {id} wasn't found");
                    return NotFound();
                }
                return Ok(order);
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while getting order with id {id}", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }

        }

        /// <summary>
        /// Add a new order.
        /// </summary>
        // POST api/orders
        [HttpPost(Name = "AddOrder")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody]OrderModel orderModel)
        {
            try
            {
                if (orderModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _iOrderService.Insert(orderModel);

                return CreatedAtRoute("AddOrder", orderModel);
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while adding a new order", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        /// <summary>
        /// Put an order.
        /// </summary>
        // PUT api/orders/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(Guid id, [FromBody]OrderModel orderModel)
        {
            try
            {
                if (orderModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var order = await _iOrderService.GetById(id);
                if (order != null)
                {
                    return NotFound();
                }

                await _iOrderService.Update(order);

                return NoContent();
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while puting an order", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }
        
        /// <summary>
        /// Delete order by id.
        /// </summary>
        // DELETE api/orders/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var order = await _iOrderService.GetById(id);
                if (order != null)
                {
                    return NotFound();
                }

                await _iOrderService.Delete(order);

                return NoContent();
            }
            catch (Exception ex)
            {
                _iLogger.LogCritical($"Exception while deleting an order", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        private bool OrderExists(Guid id)
        {
            return _iOrderService.GetAll().Any(a => a.Id.Equals(id));
        }
    }
}

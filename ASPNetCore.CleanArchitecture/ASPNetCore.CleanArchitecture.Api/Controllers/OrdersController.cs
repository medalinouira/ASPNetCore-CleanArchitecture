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

namespace ASPNetCore.CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        #region Fields
        private readonly IOrderService _iOrderService;
        private readonly ILogger<OrdersController> _iLogger;
        #endregion

        #region Constructor
        public OrdersController(IOrderService _iOrderService,
                               ILogger<OrdersController> _iLogger)
        {
            this._iLogger = _iLogger;
            this._iOrderService = _iOrderService;
        }
        #endregion

        #region Actions
        /// <summary>
        /// Get all orders.
        /// </summary>
        // GET: api/orders
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            var orders = await _iOrderService.GetAllAsync();
            if (orders != null && orders.Count() > 0)
            {
                return Ok(orders);
            }
            return NoContent();
        }

        /// <summary>
        /// Get order by id.
        /// </summary>
        // GET api/orders
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(Guid id)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            var order = await _iOrderService.GetByIdAsync(id);
            if (order == null)
            {
                _iLogger.LogInformation($"Order with {id} wasn't found");
                return NotFound();
            }
            return Ok(order);
        }

        /// <summary>
        /// Add a new order.
        /// </summary>
        // POST api/orders
        [HttpPost]
        [ValidateModelSate]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody]OrderModel orderModel)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            var createdOrder = await _iOrderService.AddAsync(orderModel);

            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder.Id);
        }

        /// <summary>
        /// Put an order.
        /// </summary>
        // PUT api/orders/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpPut("{id}")]
        [ValidateModelSate]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Put(Guid id, [FromBody]OrderModel orderModel)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            if (!(await OrderExists(id)))
            {
                return NotFound();
            }

            _iOrderService.Update(orderModel);

            return NoContent();
        }

        /// <summary>
        /// Delete order by id.
        /// </summary>
        // DELETE api/orders/386a8d02-c13a-4f98-8edd-27ece9ee0472
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete(Guid id)
        {
            _iLogger.LogInformation($"Controller : {this.GetControllerName()} , Action {this.GetActionName()} : => Visited at {DateTime.UtcNow.ToLongTimeString()}");

            if (!(await OrderExists(id)))
            {
                return NotFound();
            }

            _iOrderService.DeleteById(id);

            return NoContent();
        }

        private async Task<bool> OrderExists(Guid id)
        {
            return (await _iOrderService.GetAllAsync()).Any(a => a.Id.Equals(id));
        }
        #endregion
    }
}

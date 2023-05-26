using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using ApplicationService.UnitOfWork;

namespace WebAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var list = await _unitOfWork.OrderService.Get();
            if (list == null)
            {
                return NotFound();
            }
            return list.ToList();
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var list = await _unitOfWork.OrderService.Get();
            if (list == null)
            {
                return NotFound();
            }
            var order = await _unitOfWork.OrderService.GetFirst(c => c.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            await _unitOfWork.OrderService.Update(order);
            return NoContent();
        }

        // POST: api/Order
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _unitOfWork.OrderService.Add(order);
            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var list = await _unitOfWork.OrderService.Get();
            if (list == null)
            {
                return NotFound();
            }
            var order = await _unitOfWork.OrderService.GetFirst(c => c.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            await _unitOfWork.OrderService.Delete(order);

            return NoContent();
        }
    }
}

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
    [Route("api/orderdetail")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public OrderDetailController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/OrderDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDetail>>> GetOrderDetails()
        {
            if (_unitOfWork.OrderDetailService.Get() == null)
            {
                return NotFound();
            }
            var orderDetails = await _unitOfWork.OrderDetailService.Get();
            return orderDetails.ToList();
        }

        // GET: api/OrderDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetail>> GetOrderDetail(int id)
        {
            if (_unitOfWork.OrderDetailService.Get() == null)
            {
                return NotFound();
            }
            var orderDetail = await _unitOfWork.OrderDetailService.GetFirst(c => c.OrderId == id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return orderDetail;
        }

        // PUT: api/OrderDetail/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderDetail(int id, OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderId)
            {
                return BadRequest();
            }

            await _unitOfWork.OrderDetailService.Update(orderDetail);
            return NoContent();
        }

        // POST: api/OrderDetail
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderDetail>> PostOrderDetail(OrderDetail orderDetail)
        {
            await _unitOfWork.OrderDetailService.Add(orderDetail);
            return CreatedAtAction("GetOrderDetail", new { id = orderDetail.OrderId }, orderDetail);
        }

        // DELETE: api/OrderDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            if (_unitOfWork.OrderDetailService.Get() == null)
            {
                return NotFound();
            }
            var orderDetail = await _unitOfWork.OrderDetailService.GetFirst(c => c.OrderId == id);
            if (orderDetail == null)
            {
                return NotFound();
            }

            await _unitOfWork.OrderDetailService.Delete(orderDetail);

            return NoContent();
        }
    }
}

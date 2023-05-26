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
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Supplier
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            var list = await _unitOfWork.SupplierService.Get();
            if (list == null)
            {
                return NotFound();
            }
            return list.ToList();
        }

        // GET: api/Supplier/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var list = await _unitOfWork.SupplierService.Get();
            if (list == null)
            {
                return NotFound();
            }
            var supplier = await _unitOfWork.SupplierService.GetFirst(c => c.SupplierId == id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        // PUT: api/Supplier/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return BadRequest();
            }

            await _unitOfWork.SupplierService.Update(supplier);
            return NoContent();
        }

        // POST: api/Supplier
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            await _unitOfWork.SupplierService.Add(supplier);
            return CreatedAtAction("GetSupplier", new { id = supplier.SupplierId }, supplier);
        }

        // DELETE: api/Supplier/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var list = await _unitOfWork.SupplierService.Get();
            if (list == null)
            {
                return NotFound();
            }
            var supplier = await _unitOfWork.SupplierService.GetFirst(c => c.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }

            await _unitOfWork.SupplierService.Delete(supplier);

            return NoContent();
        }
    }
}

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
    [Route("api/flowerbouquet")]
    [ApiController]
    public class FlowerBouquetController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public FlowerBouquetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/FlowerBouquet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlowerBouquet>>> GetFlowerBouquets()
        {
            var list = await _unitOfWork.FlowerBouquetService.Get();
            if (list == null)
            {
                return NotFound();
            }
            return list.ToList();
        }

        // GET: api/FlowerBouquet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FlowerBouquet>> GetFlowerBouquet(int id)
        {
            var list = await _unitOfWork.FlowerBouquetService.Get();
            if (list == null)
            {
                return NotFound();
            }
            var flowerBouquet = await _unitOfWork.FlowerBouquetService.GetFirst(c => c.FlowerBouquetId == id);

            if (flowerBouquet == null)
            {
                return NotFound();
            }

            return flowerBouquet;
        }

        // PUT: api/FlowerBouquet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlowerBouquet(int id, FlowerBouquet flowerBouquet)
        {
            if (id != flowerBouquet.FlowerBouquetId)
            {
                return BadRequest();
            }

            await _unitOfWork.FlowerBouquetService.Update(flowerBouquet);

            return NoContent();
        }

        // POST: api/FlowerBouquet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FlowerBouquet>> PostFlowerBouquet(FlowerBouquet flowerBouquet)
        {
            await _unitOfWork.FlowerBouquetService.Add(flowerBouquet);
            return CreatedAtAction("GetFlowerBouquet", new { id = flowerBouquet.FlowerBouquetId }, flowerBouquet);
        }

        // DELETE: api/FlowerBouquet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlowerBouquet(int id)
        {
            var list = await _unitOfWork.FlowerBouquetService.Get();
            if (list == null)
            {
                return NotFound();
            }
            var flowerBouquet = await _unitOfWork.FlowerBouquetService.GetFirst(c => c.FlowerBouquetId == id);
            if (flowerBouquet == null)
            {
                return NotFound();
            }

            await _unitOfWork.FlowerBouquetService.Delete(flowerBouquet);

            return NoContent();
        }
    }
}

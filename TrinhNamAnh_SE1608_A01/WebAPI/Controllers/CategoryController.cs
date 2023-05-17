using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BussinessObject.Models;
using ApplicationService.UnitOfWork;

namespace WebAPi.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            if (_unitOfWork.CategoryService.Get() == null)
            {
                return NotFound();
            }
            var list = await _unitOfWork.CategoryService.Get();
            return list.ToList();
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            if (_unitOfWork.CategoryService.Get() == null)
            {
                return NotFound();
            }
            var category = await _unitOfWork.CategoryService.GetFirst(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }
            var found = _unitOfWork.CategoryService.GetFirst(c => c.CategoryId == id);
            if(found == null)
            {
                return NotFound();
            }
            await _unitOfWork.CategoryService.Update(category);
            return NoContent();
        }

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            await _unitOfWork.CategoryService.Add(category);
            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (_unitOfWork.CategoryService.Get() == null)
            {
                return NotFound();
            }
            var category = await _unitOfWork.CategoryService.GetFirst(c => c.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            await _unitOfWork.CategoryService.Delete(category);

            return NoContent();
        }
    }
}

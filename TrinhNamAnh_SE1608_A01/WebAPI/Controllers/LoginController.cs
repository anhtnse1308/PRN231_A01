using ApplicationService.UnitOfWork;
using BussinessObject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<LoginController>
        [HttpGet]
        public async Task<ActionResult<Category>> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is null or empty");
            }
            Customer customer = null;
            var admin= Extension.Helper.ImportJson();
            if(admin.Email == email && admin.Password == password)
            {
                customer = admin;
            }
            else
            {
                var users = await _unitOfWork.CustomerService.Get();
                var user = users.FirstOrDefault(x => x.Email == email && x.Password == password);
                if(user != null)
                {
                    customer = user;
                    return Ok(customer);
                }
            }
            return BadRequest("Login failed please check email or password");
        }
    }
}

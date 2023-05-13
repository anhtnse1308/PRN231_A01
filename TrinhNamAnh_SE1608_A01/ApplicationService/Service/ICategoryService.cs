
using BussinessObject.Models;
using ApplicationService.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Service
{
    public interface ICategoryService : IGenericRepository<Category>
    {
    }
}

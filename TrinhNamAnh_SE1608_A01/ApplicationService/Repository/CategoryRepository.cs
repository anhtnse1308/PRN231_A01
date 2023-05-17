using BussinessObject.Models;
using ApplicationService.Generic;
using ApplicationService.Service;
using ApplicationService.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryService
    {
        public CategoryRepository(FUFlowerBouquetManagementContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}

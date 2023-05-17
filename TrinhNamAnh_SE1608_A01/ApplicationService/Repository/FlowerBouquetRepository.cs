using ApplicationService.Generic;
using ApplicationService.Service;
using ApplicationService.UnitOfWork;
using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Repository
{
    public class FlowerBouquetRepository : GenericRepository<FlowerBouquet>, IFlowerBouquetService
    {
        public FlowerBouquetRepository(FUFlowerBouquetManagementContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}

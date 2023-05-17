using ApplicationService.Generic;
using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Service
{
    public interface IOrderDetailService : IGenericRepository<OrderDetail>
    {
    }
}

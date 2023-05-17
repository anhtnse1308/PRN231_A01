using ApplicationService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ICategoryService CategoryService { get; }
        public ICustomerService CustomerService { get; }
        public IFlowerBouquetService FlowerBouquetService { get; }
        public IOrderService OrderService { get; }
        public IOrderDetailService OrderDetailService { get; }
        public ISupplierService SupplierService { get; }
    }
}

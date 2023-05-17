using BussinessObject.Models;
using ApplicationService.Repository;
using ApplicationService.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryService CategoryService { get; private set; } = null!;

        public ICustomerService CustomerService { get; private set; } = null!;

        public IFlowerBouquetService FlowerBouquetService { get; private set; } = null!;

        public IOrderService OrderService { get; private set; } = null!;

        public IOrderDetailService OrderDetailService { get; private set; } = null!;

        public ISupplierService SupplierService { get; private set; } = null!;

        private readonly FUFlowerBouquetManagementContext _context;

        public UnitOfWork(FUFlowerBouquetManagementContext context)
        {
            _context = context;
            InitRepositories();
        }

        private void InitRepositories()
        {
            CategoryService = new CategoryRepository(_context, this);
            CustomerService = new CustomerRepository(_context, this);
            FlowerBouquetService = new FlowerBouquetRepository(_context, this);
            OrderService = new OrderRepository(_context, this);
            OrderDetailService = new OrderDetailRepository(_context, this);
            SupplierService = new SupplierRepository(_context, this);
        }
    }
}

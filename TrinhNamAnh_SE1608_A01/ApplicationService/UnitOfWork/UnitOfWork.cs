
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

        private readonly FUFlowerBouquetManagementContext _context;

        public UnitOfWork(FUFlowerBouquetManagementContext context)
        {
            _context = context;
            InitRepositories();
        }

        private void InitRepositories()
        {
            CategoryService = new CategoryRepository(_context, this);
        }
    }
}

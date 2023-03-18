using Core.Repositories;
using DataAccess.Abstracts;
using DataAccess.Concreate.Contexts;
using DataAccess.Entities;

namespace DataAccess.Concreate.Repositories
{
    public class ProductRepository : GenericRepository<Product, ApplicationDbContext>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}

using AngularETicaret.Core.DBModels;
using AngularETicaret.Core.Interfaces;
using AngularETicaret.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngularETicaret.Infrastructure.Implements
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }
     
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(x => x.ProductType).FirstOrDefaultAsync(x=>x.Id==id);
        }
        public async Task<IReadOnlyList<Product>> GetProductAsync()
        {
            return await _context.Products.Include(p=>p.ProductBrand).Include(x=>x.ProductType).ToListAsync();
        }

        //public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        //{
        //   return await _context.p
        //}

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}

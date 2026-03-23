using Microsoft.EntityFrameworkCore;
using ProductManagement.Application.Intertfaces;
using ProductManagement.Domain.Enitity;
using ProductManagement.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly ApplicationDbContext _context; 

       public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(int page,int  pageSize)
        {
            return await _context.Products.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

        }

        public async Task<Product?> GetByIdAsync(int id)
        {

            return await  _context.Products.FindAsync(id);

        }

        public async Task<Product> AddProductAsync(Product product)
        {

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;


        }

      public async  Task<bool> UpdateProductAsync(Product product)
        {
            _context.Products.Update(product);
            return await _context.SaveChangesAsync() > 0;
                


        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return false;

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync() > 0;
           

        }

    }
}

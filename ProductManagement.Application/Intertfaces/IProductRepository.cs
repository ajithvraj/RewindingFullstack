using ProductManagement.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Intertfaces
{
    public interface IProductRepository
    { 
        Task<IEnumerable<Product>> GetAllProductsAsync(int page, int pageSize); 
        Task<Product?> GetByIdAsync(int id); 
        Task<Product> AddProductAsync(Product product); 
        Task<bool> UpdateProductAsync(Product product); 
        Task<bool> DeleteProductAsync(int id);


       


    }
}

using ProductManagement.Api.Common;
using ProductManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ApiResponse<IEnumerable<ProductResponsDto>>> GetAllProductsAsync(int page , int pageSize);
        Task<ApiResponse<IEnumerable<ProductResponsDto>>> GetProductbyIdAsync(int id);
        Task<ApiResponse<ProductResponsDto>> CreateProductAsync(CreateProductDto create);
        Task<ApiResponse<bool>> UpdateProductAsync(int id , UpdateProductDto update);
        Task<ApiResponse<bool>> DeleteProductAsync(int id);

    }
}

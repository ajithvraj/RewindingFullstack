using Microsoft.Extensions.Logging;
using ProductManagement.Api.Common;
using ProductManagement.Application.DTOs;
using ProductManagement.Application.Intertfaces;
using ProductManagement.Application.Services.Interfaces;
using ProductManagement.Domain.Enitity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Application.Services
{
    public class ProductService : IProductService 
    {

        private readonly IProductRepository _repo;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepository repo,ILogger<ProductService> logger)
        {
            _repo = repo;
            _logger = logger;
        }


       public async Task<ApiResponse<IEnumerable<ProductResponsDto>>> GetAllProductsAsync(int page, int pageSize)
        {
            var products = await _repo.GetAllProductsAsync(page, pageSize);

            var result = products.Select(p => new ProductResponsDto
            {
                Id = p.Id,
                Name = p.Name,
                Stock = p.Stock,
                Price = p.Price,

            });

            return new ApiResponse<IEnumerable<ProductResponsDto>>
            {
                Success = true,
                Message = "All products fetched",
                Data = result

            };



            

        }
       public async  Task<ApiResponse<IEnumerable<ProductResponsDto>>> GetProductbyIdAsync(int id)
        {
            var product = await _repo.GetByIdAsync(id); 

            if(product == null)
            {

                return new ApiResponse<IEnumerable<ProductResponsDto>>
                {
                    Success = false ,
                    Message = "No products found "

                };

                

                
               

            }
            var result = new ProductResponsDto
            {
                Id = product.Id,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price,


            };

            return new ApiResponse<IEnumerable<ProductResponsDto>>
            {
                Success = true,
                Message = "Product fetched successfully",
                Data = new List<ProductResponsDto> { result }
            };
        }
        public async Task<ApiResponse<ProductResponsDto>> CreateProductAsync(CreateProductDto create)
        {
            if (string.IsNullOrWhiteSpace(create.Name))
            {

                return new ApiResponse<ProductResponsDto>
                {
                    Success = false ,
                    Message = "Validation failed" ,
                    Errors = new List<string> { "Name is required"}

                };

            }

            if(create.Price <= 0)
            {
                return new ApiResponse<ProductResponsDto>
                {
                    Success = false,
                    Message = "Validation failed",
                    Errors = new List<string> {"Price must be grater than zero"}


                };

            }
            var product = new Product
            {
                Name = create.Name,
                Price = create.Price,
                Stock = create.Stock,
                

            };

            var created = await _repo.AddProductAsync(product);

            var result = new ProductResponsDto
            {
                Id = created.Id,
                Name = created.Name,
                Price = created.Price,
                Stock = created.Stock



            };

            _logger.LogInformation("Product created with ID : {id}" , created.Id);

            return new ApiResponse<ProductResponsDto>
            {
                Success = true ,
                Message = "Product created successfully",
                Data = result

            };




        }
       public async Task<ApiResponse<bool>> UpdateProductAsync(int id, UpdateProductDto update)
        {
            var exist = await _repo.GetByIdAsync(id); 

            if(exist == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Product not found"
                };

            }

            if(string.IsNullOrWhiteSpace(update.Name))
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Product should have a name"
                };

            }

            if(update.Price <= 0)
            {

                return new ApiResponse<bool>
                {

                    Success = false,
                    Message = "Price must be grater than zero"

                };

            }

            exist.Name = update.Name;
            exist.Price = update.Price;
            exist.Stock = update.Stock;

            var updated = await _repo.UpdateProductAsync(exist);

            return new ApiResponse<bool>
            {
                Success = true,
                Message = updated ? "Product successfully updated" : "Updation failed"
                


            };


        }
       public async Task<ApiResponse<bool>> DeleteProductAsync(int id)
        {

            var deleted = await _repo.DeleteProductAsync(id); 

            if(!deleted)
            {

                return new ApiResponse<bool>
                {
                    Success = false,
                    Message = "No product found"
                };



            }


            return new ApiResponse<bool>
            {
                Success = true ,
                Message = "Product deleted"



            };




        }
    }
}

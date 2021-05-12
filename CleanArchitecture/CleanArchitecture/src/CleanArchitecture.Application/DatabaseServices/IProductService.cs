using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DatabaseServices
{
    public interface IProductService
    {
        Task<bool> CreateProductAsync(CreateProductCommandRequestModel request);
        Task<bool> UpdateProductAsync(UpdateProductCommandRequestModel request);
        Task<bool> DeleteProductAsync(Guid productId);
        Task<IEnumerable<ProductQueryResponseModel>> GetAllProductAsync();
        Task<ProductQueryResponseModel> GetByIdProductAsync(Guid productId);
    }
}

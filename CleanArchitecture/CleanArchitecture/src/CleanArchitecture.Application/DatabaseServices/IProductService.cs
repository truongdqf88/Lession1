using CleanArchitecture.Application.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.DatabaseServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(Guid id);

        Task<bool> CreateProductAsync(Product request);

        Task<bool> UpdateProductAsync(Product request);

        Task<bool> DeleteProductAsync(Guid id);
    }
}

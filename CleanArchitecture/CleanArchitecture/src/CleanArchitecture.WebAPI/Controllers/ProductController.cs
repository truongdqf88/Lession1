using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.GetProductsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> Get(Guid id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        [HttpPost]
        public async Task<bool> Post(Product request)
        {
            return await _productService.CreateProductAsync(request);
        }

        [HttpPut]
        public async Task<bool> Put(Product request)
        {
            return await _productService.UpdateProductAsync(request);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(Guid id)
        {
            return await _productService.DeleteProductAsync(id);
        }
    }
}

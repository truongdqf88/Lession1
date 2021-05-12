using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequestModel, ProductCommandResponseModel>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductCommandResponseModel> Handle(CreateProductCommandRequestModel request, CancellationToken cancellationToken)
        {
            bool isSuccess = await _productService.CreateProductAsync(request);

            return new ProductCommandResponseModel()
            {
                IsSuccess = isSuccess
            };
        }
    }
}

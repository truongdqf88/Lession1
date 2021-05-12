using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handler
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequestModel, ProductCommandResponseModel>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductCommandResponseModel> Handle(UpdateProductCommandRequestModel request, CancellationToken cancellationToken)
        {
            var isSuccess = await _productService.UpdateProductAsync(request);

            return new ProductCommandResponseModel()
            {
                IsSuccess = isSuccess
            };
        }
    }
}

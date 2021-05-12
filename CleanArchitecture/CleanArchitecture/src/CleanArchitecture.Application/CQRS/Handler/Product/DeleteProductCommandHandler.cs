using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handler
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequestModel, ProductCommandResponseModel>
    {
        private readonly IProductService _productService;

        public DeleteProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductCommandResponseModel> Handle(DeleteProductCommandRequestModel request, CancellationToken cancellationToken)
        {
            bool isSuccess = await _productService.DeleteProductAsync(request.ProductID);

            return new ProductCommandResponseModel()
            {
                IsSuccess = isSuccess
            };
        }
    }
}

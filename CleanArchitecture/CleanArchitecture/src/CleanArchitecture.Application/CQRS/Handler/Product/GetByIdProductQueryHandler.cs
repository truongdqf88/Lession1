using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handler
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequestModel, ProductQueryResponseModel>
    {
        private readonly IProductService _productService;

        public GetByIdProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductQueryResponseModel> Handle(GetByIdProductQueryRequestModel request, CancellationToken cancellationToken)
        {
            return await _productService.GetByIdProductAsync(request.ProductID);
        }
    }
}

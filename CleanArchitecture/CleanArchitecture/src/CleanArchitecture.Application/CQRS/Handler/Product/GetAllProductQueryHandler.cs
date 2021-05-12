using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Handler
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequestModel, IEnumerable<ProductQueryResponseModel>>
    {
        private readonly IProductService _productService;

        public GetAllProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IEnumerable<ProductQueryResponseModel>> Handle(GetAllProductQueryRequestModel request, CancellationToken cancellationToken)
        {
            return await _productService.GetAllProductAsync();
        }
    }
}

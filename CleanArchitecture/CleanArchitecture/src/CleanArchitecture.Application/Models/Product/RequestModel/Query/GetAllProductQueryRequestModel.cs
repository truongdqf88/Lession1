using MediatR;
using System.Collections.Generic;

namespace CleanArchitecture.Application.Models
{
    public class GetAllProductQueryRequestModel : IRequest<IEnumerable<ProductQueryResponseModel>>
    {
    }
}

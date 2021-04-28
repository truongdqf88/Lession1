using MediatR;
using System;

namespace CleanArchitecture.Application.Models
{
    public class GetByIdProductQueryRequestModel : IRequest<ProductQueryResponseModel>
    {
        public Guid ProductID { get; set; }
    }
}

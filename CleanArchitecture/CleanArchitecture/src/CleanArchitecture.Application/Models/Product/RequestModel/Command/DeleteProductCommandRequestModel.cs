using MediatR;
using System;

namespace CleanArchitecture.Application.Models
{
    public class DeleteProductCommandRequestModel : IRequest<ProductCommandResponseModel>
    {
        public Guid ProductID { get; set; }
    }
}

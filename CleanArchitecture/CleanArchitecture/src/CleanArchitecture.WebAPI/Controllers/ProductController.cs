using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using MediatR;
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
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductQueryResponseModel>> Get()
        {
            GetAllProductQueryRequestModel request = new GetAllProductQueryRequestModel();
            return await _mediator.Send(request);
        }

        [HttpGet("{id}")]
        public async Task<ProductQueryResponseModel> Get(Guid id)
        {
            GetByIdProductQueryRequestModel request = new GetByIdProductQueryRequestModel()
            {
                ProductID = id
            };
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<ProductCommandResponseModel> Post(CreateProductCommandRequestModel request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<ProductCommandResponseModel> Put(UpdateProductCommandRequestModel request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<ProductCommandResponseModel> Delete(Guid id)
        {
            DeleteProductCommandRequestModel request = new DeleteProductCommandRequestModel()
            {
                ProductID = id
            };
            return await _mediator.Send(request);
        }
    }
}

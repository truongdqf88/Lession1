using CleanArchitecture.Application.Models;
using CleanArchitecture.Infrastructure.DatabaseServices;
using Dapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Handler.Product
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequestModel, ProductCommandResponseModel>
    {
        private readonly IDatabaseConnectionFactory _database;

        public DeleteProductCommandHandler(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<ProductCommandResponseModel> Handle(DeleteProductCommandRequestModel request, CancellationToken cancellationToken)
        {
            using (var conn = await _database.CreateConnectionAsync())
            {
                int affected = await conn.ExecuteAsync("DELETE FROM Product WHERE ProductID = @ProductID", new { ProductID = request.ProductID });

                return new ProductCommandResponseModel()
                {
                    IsSuccess = affected > 0
                };
            }
        }
    }
}

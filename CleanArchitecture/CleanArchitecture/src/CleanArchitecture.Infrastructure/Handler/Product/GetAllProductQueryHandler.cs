using CleanArchitecture.Application.Models;
using CleanArchitecture.Infrastructure.DatabaseServices;
using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Handler.Product
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequestModel, IEnumerable<ProductQueryResponseModel>>
    {
        private readonly IDatabaseConnectionFactory _database;

        public GetAllProductQueryHandler(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<IEnumerable<ProductQueryResponseModel>> Handle(GetAllProductQueryRequestModel request, CancellationToken cancellationToken)
        {
            using (var conn = await _database.CreateConnectionAsync())
            {
                return await conn.QueryAsync<ProductQueryResponseModel>("SELECT * FROM Product");
            }
        }
    }
}

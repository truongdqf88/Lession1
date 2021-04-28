using CleanArchitecture.Application.Models;
using CleanArchitecture.Infrastructure.DatabaseServices;
using Dapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Handler
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequestModel, ProductQueryResponseModel>
    {
        private readonly IDatabaseConnectionFactory _database;

        public GetByIdProductQueryHandler(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<ProductQueryResponseModel> Handle(GetByIdProductQueryRequestModel request, CancellationToken cancellationToken)
        {
            using (var conn = await _database.CreateConnectionAsync())
            {
                return await conn.QueryFirstOrDefaultAsync<ProductQueryResponseModel>("SELECT * FROM Product WHERE ProductID = @ProductID", new { ProductID = request.ProductID });
            }
        }
    }
}

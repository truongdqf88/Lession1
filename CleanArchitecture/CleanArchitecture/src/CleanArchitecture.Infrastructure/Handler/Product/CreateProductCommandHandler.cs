using CleanArchitecture.Application.Models;
using CleanArchitecture.Infrastructure.DatabaseServices;
using MediatR;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Handler
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequestModel, ProductCommandResponseModel>
    {
        private readonly IDatabaseConnectionFactory _database;

        public CreateProductCommandHandler(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<ProductCommandResponseModel> Handle(CreateProductCommandRequestModel request, CancellationToken cancellationToken)
        {
            using (var conn = await _database.CreateConnectionAsync())
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());
                int affected = await db.Query("Product")
                                       .InsertAsync(new
                                       {
                                           ProductID = Guid.NewGuid(),
                                           ProductKey = request.ProductKey,
                                           ProductName = request.ProductName,
                                           ProductImageUri = request.ProductImageUri,
                                           ProductTypeID = request.ProductTypeID,
                                           RecordStatus = (short)request.RecordStatus,
                                           CreatedDate = DateTime.UtcNow,
                                           UpdatedUser = Guid.NewGuid(),
                                           UpdatedDate = DateTime.UtcNow
                                       });

                return new ProductCommandResponseModel()
                {
                    IsSuccess = affected > 0
                };
            }
        }
    }
}

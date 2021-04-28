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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequestModel, ProductCommandResponseModel>
    {
        private readonly IDatabaseConnectionFactory _database;

        public UpdateProductCommandHandler(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<ProductCommandResponseModel> Handle(UpdateProductCommandRequestModel request, CancellationToken cancellationToken)
        {
            using (var conn = await _database.CreateConnectionAsync())
            {
                var db = new QueryFactory(conn, new SqlServerCompiler());
                int affected = await db.Query("Product")
                                       .Where("ProductID", request.ProductID)
                                       .UpdateAsync(new
                                       {
                                           ProductKey = request.ProductKey,
                                           ProductName = request.ProductName,
                                           ProductImageUri = request.ProductImageUri,
                                           ProductTypeID = request.ProductTypeID,
                                           RecordStatus = (short)request.RecordStatus,
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

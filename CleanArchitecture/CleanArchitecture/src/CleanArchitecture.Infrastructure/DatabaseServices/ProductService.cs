using CleanArchitecture.Application.DatabaseServices;
using CleanArchitecture.Application.Models;
using Dapper;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.DatabaseServices
{
    public class ProductService : IProductService
    {
        private readonly IDatabaseConnectionFactory _database;

        public ProductService(IDatabaseConnectionFactory database)
        {
            _database = database;
        }

        public async Task<bool> CreateProductAsync(CreateProductCommandRequestModel request)
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

                return affected > 0;
            }
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            using (var conn = await _database.CreateConnectionAsync())
            {
                int affected = await conn.ExecuteAsync("DELETE FROM Product WHERE ProductID = @ProductID", new { ProductID = productId });

                return affected > 0;
            }
        }

        public async Task<IEnumerable<ProductQueryResponseModel>> GetAllProductAsync()
        {
            using (var conn = await _database.CreateConnectionAsync())
            {
                return await conn.QueryAsync<ProductQueryResponseModel>("SELECT * FROM Product");
            }
        }

        public async Task<ProductQueryResponseModel> GetByIdProductAsync(Guid productId)
        {
            using (var conn = await _database.CreateConnectionAsync())
            {
                return await conn.QueryFirstOrDefaultAsync<ProductQueryResponseModel>("SELECT * FROM Product WHERE ProductID = @ProductID", new { ProductID = productId });
            }
        }

        public async Task<bool> UpdateProductAsync(UpdateProductCommandRequestModel request)
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

                return affected > 0;
            }
        }
    }
}

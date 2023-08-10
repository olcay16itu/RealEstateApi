using Dapper;
using RealEstateApi.Models.DapperContext;
using RealEstateApi.Models.DTOs.ProductDTOs;

namespace RealEstateApi.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context context;

        public ProductRepository(Context context)
        {
            this.context = context;
        }

        public async Task<List<ResultProductDTO>> GetAllAsync()
        {
            string query = "select * from Product";
            using(var connection = context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDTO>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDTO>> GetAllProductWithCategory()
        {
            string query = "select * from Product p inner join Category c on c.Category_ID=p.Product_Category";
            using (var connection = context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDTO>(query);
                return values.ToList();
            }
        }
    }
}

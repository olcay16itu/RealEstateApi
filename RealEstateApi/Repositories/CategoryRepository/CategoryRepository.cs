using Dapper;
using RealEstateApi.Models.DapperContext;
using RealEstateApi.Models.DTOs.CategoryDTOs;
using System.Reflection.Metadata;

namespace RealEstateApi.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public readonly Context context;

        public CategoryRepository(Context context)
        {
            this.context = context;
        }

        public async void AddCategoryAsync(CreateCategoryDTO createCategoryDTO)
        {
            string query = "insert into Category  (Category_name,Category_status) values (@categoryName,@categoryStatus)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryName", createCategoryDTO.Category_name);
            paramaters.Add("@categoryStatus", true);
            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async void DeleteCategory(int id)
        {
            string query = "delete from Category where Category_ID=@id";
            var paramaters = new DynamicParameters();
            paramaters.Add("@id", id);
            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultCategoryDTO>> getAllResultsAsync()
        {
            string query = "select * from Category";
            using (var connection = context.CreateConnection()) 
            {   
                var values = await connection.QueryAsync<ResultCategoryDTO>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDCategoryDTO> GetCategory(int id)
        {
            string query = "select * from Category where Category_ID=@id";
            var paramaters = new DynamicParameters();
            paramaters.Add("@id", id);
            using (var connection = context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetByIDCategoryDTO>(query, paramaters);
                return value;
            }
        }

        public async void UpdateCategoryAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            string query = "update Category set Category_name=@name,Category_status=@status where Category_ID=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id",updateCategoryDTO.Category_ID);
            parameters.Add("@name", updateCategoryDTO.Category_name);
            parameters.Add("@status", updateCategoryDTO.Category_status);
            using (var connection = context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}

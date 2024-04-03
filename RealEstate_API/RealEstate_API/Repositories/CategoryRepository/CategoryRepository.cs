using System;
using Dapper;
using RealEstate_API.DAL;
using RealEstate_API.Dtos.CategoryDtos;

namespace RealEstate_API.Repositories.CategoryRepository
{
	public class CategoryRepository: ICategoryRepository
    {
        private readonly DataContext _dataContext;
		public CategoryRepository(DataContext dataContext)
		{
            _dataContext = dataContext;
		}

        public async Task Create(CreateCategoryDto createCategoryDto)
        {
            string query = "insert into Category(Name,IsDeleted,CreatedAt) VALUES(@categoryName,@categoryStatus,@categoryCreateDate)";
            using(var connection = _dataContext.CreateConnection())
            {
                DynamicParameters parameters = new();
                parameters.Add("@categoryName", createCategoryDto.Name);
                parameters.Add("@categoryStatus", false);
                parameters.Add("@categoryCreateDate", DateTime.Now);
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task Delete(int id)
        {
            string query = "update  category set isDeleted=@isDeleted,deletedAt=@deletedAt where id=@categoryId";
            DynamicParameters parameters = new();
            parameters.Add("@categoryId", id);
            parameters.Add("@isDeleted", true);
            parameters.Add("@deletedAt", DateTime.Now);
            using (var connection = _dataContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResoultCategoryDto>> GetAllCategoryAsync()
        {
            string query = "Select*From Category";
            using(var connection = _dataContext.CreateConnection())
            {
                var data = await connection.QueryAsync<ResoultCategoryDto>(query);
                return data.ToList();
            };
        }

        public async Task<ResoultCategoryDto> GetCategoryById(int id)
        {
            string query = "select*from category where id=@cateoryId";
            DynamicParameters parametrs = new DynamicParameters();
            parametrs.Add("@cateoryId", id);
            using(var connection = _dataContext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<ResoultCategoryDto>(query, parametrs);
            }
        }

        public async Task Update(UpdateCategoryDto updateCategoryDto)
        {
            string query = "update category set name=@categoryName,isDeleted=@categoryStatus,deletedAt=@deletedAt,UpdatedAt=@UpdatedAt where id=@categoryId";
            DynamicParameters parameters = new();
            parameters.Add("@categoryName", updateCategoryDto.Name);
            parameters.Add("@categoryStatus", updateCategoryDto.IsDeleted);
            parameters.Add("@categoryId", updateCategoryDto.Id);
            parameters.Add("@deletedAt", updateCategoryDto.IsDeleted?DateTime.Now:null);
            parameters.Add("@UpdatedAt", DateTime.Now);
            using (var connection = _dataContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}


using System;
using Dapper;
using RealEstate_API.DAL;
using RealEstate_API.Dtos.SettingDtos;

namespace RealEstate_API.Repositories.SettingRepository
{
	public class SettingRepository: ISettingRepository
    {
        private readonly DataContext _dataContext;
        public SettingRepository(DataContext dataContext)
		{
            _dataContext = dataContext;
		}

        public async Task Create(CreateSettingDto createSettingDto)
        {
            string query = "Insert Into Setting([Key],Value,IsDeleted,CreatedAt) values(@key,@value,@isDeleted,@createdAt)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@key", createSettingDto.Key);
            dynamicParameters.Add("@value", createSettingDto.Value);
            dynamicParameters.Add("@isDeleted", false);
            dynamicParameters.Add("@createdAt", DateTime.Now);
            using(var connection = _dataContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async Task<int> Delete(int id)
        {
            string query = "update Setting set isDeleted=@isDeleted,DeletedAt=@deletedAt where Id=@id and isDeleted!=@isDeleted ";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@id", id);
            dynamicParameters.Add("@isDeleted", true);
            dynamicParameters.Add("@DeletedAt", DateTime.Now);
            using(var connection = _dataContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async Task<List<ResoultSettingDto>> Get()
        {
            string query = "select*from Setting";
            using(var connection = _dataContext.CreateConnection())
            {
               return (await connection.QueryAsync<ResoultSettingDto>(query)).ToList();
            }
        }

        public async Task<ResoultSettingDto> Get(int id)
        {
            string query = "select*from Setting where id=@id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@id", id);
            using(var connection = _dataContext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<ResoultSettingDto>(query,dynamicParameters);
            }
        }

        public async Task<int> Update(UpdateSettingDto updateSettingDto)
        {
            string query = "update Setting set [Key]=@key,Value=@value,IsDeleted=@isDeleted,DeletedAt=@deletedAt,UpdatedAt=@updatedAt where id=@id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@id", updateSettingDto.Id);
            dynamicParameters.Add("@key", updateSettingDto.Key);
            dynamicParameters.Add("@value", updateSettingDto.Value);
            dynamicParameters.Add("@isDeleted", updateSettingDto.IsDeleted);
            dynamicParameters.Add("@deletedAt", updateSettingDto.IsDeleted?DateTime.Now:null);
            dynamicParameters.Add("@UpdatedAt", DateTime.Now);
            using(var connection = _dataContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, dynamicParameters);
            }
        }
    }
}


using System;
using Dapper;
using RealEstate_API.DAL;
using RealEstate_API.Dtos.EmployeDtos;

namespace RealEstate_API.Repositories.EmployeRepository
{
	public class EmployeRepository: IEmployeRepository
    {
        private readonly DataContext _dataContext;
		public EmployeRepository(DataContext dataContext)
		{
            _dataContext = dataContext;
		}

        public async Task CreateEmploye(CreateEmployeDto createEmployeDto)
        {
            string query = "insert into Employees(Name,Position,ImageUrl,PublicId,PhoneNumber,IsDeleted,CreatedAt) values (@Name,@Position,@ImageUrl,@PublicId,@PhoneNumber,@IsDeleted,@CreatedAt)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Name", createEmployeDto.Name);
            dynamicParameters.Add("@ImageUrl", createEmployeDto.ImageUrl);
            dynamicParameters.Add("@PhoneNumber", createEmployeDto.PhoneNumber);
            dynamicParameters.Add("@Position", createEmployeDto.Position);
            dynamicParameters.Add("@PublicId", createEmployeDto.PublicId);
            dynamicParameters.Add("@IsDeleted", false);
            dynamicParameters.Add("@CreatedAt", DateTime.Now);
            using(var connection = _dataContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async Task<int> Delete(int id)
        {
            string query = "update  Employees set IsDeleted=@IsDeleted,DeletedAt=@DeletedAt where id=@id and IsDeleted!=@IsDeleted";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@id", id);
            dynamicParameters.Add("@IsDeleted", true);
            dynamicParameters.Add("@DeletedAt", DateTime.Now);
            using(var connection = _dataContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async Task<List<ResoultEmployeDto>> GetAll()
        {
            string query = "select*from Employees where IsDeleted=@IsDeleted";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@IsDeleted", false);
            using (var connection = _dataContext.CreateConnection())
            {
                var datas =await connection.QueryAsync<ResoultEmployeDto>(query,dynamicParameters);
                return datas.ToList();
            }
        }

        public async Task<List<ResoultEmployeDto>> GetAllByAdmin()
        {
            string query = "select*from Employees";
            using (var connection = _dataContext.CreateConnection())
            {
                var datas = await connection.QueryAsync<ResoultEmployeDto>(query);
                return datas.ToList();
            }
        }

        public async Task<ResoultEmployeDto> GetEmployeByAdmin(int id)
        {
            string query = "select*from Employees where Id=@id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@id", id);
            using (var connection = _dataContext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<ResoultEmployeDto>(query, dynamicParameters);

            }
        }

        public async Task<ResoultEmployeDto> GetEmployeById(int id)
        {
            string query = "select*from Employees where Id=@id and IsDeleted=@IsDeleted";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@id", id);
            dynamicParameters.Add("@IsDeleted", false);
            using (var connection = _dataContext.CreateConnection())
            {
               return await connection.QueryFirstOrDefaultAsync<ResoultEmployeDto>(query, dynamicParameters);
               
            }
        }

        public async Task<int> UpdateEmploye(UpdateEmployeDto updateEmployeDto)
        {
            string query =updateEmployeDto.Image!=null?
                "update Employees set Name=@Name,Position=@Position,ImageUrl=@ImageUrl,PublicId=@PublicId,PhoneNumber=@PhoneNumber,IsDeleted=@IsDeleted,UpdatedAt=@UpdatedAt,DeletedAt=@DeletedAt where id=@Id" :
                "update Employees set Name=@Name,Position=@Position,PhoneNumber=@PhoneNumber,IsDeleted=@IsDeleted,UpdatedAt=@UpdatedAt,DeletedAt=@DeletedAt where id=@Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", updateEmployeDto.Id);
            dynamicParameters.Add("@Name", updateEmployeDto.Name);
            dynamicParameters.Add("@Position", updateEmployeDto.Position);
            dynamicParameters.Add("@PhoneNumber", updateEmployeDto.PhoneNumber);
            dynamicParameters.Add("@IsDeleted", updateEmployeDto.IsDeleted);
            dynamicParameters.Add("@UpdatedAt", DateTime.Now);
            dynamicParameters.Add("@DeletedAt", updateEmployeDto.IsDeleted?DateTime.Now:null);
            if (updateEmployeDto.Image!=null)
            {
                dynamicParameters.Add("@ImageUrl", updateEmployeDto.ImageUrl);
                dynamicParameters.Add("@PublicId", updateEmployeDto.PublicId);
            }
            using(var connection = _dataContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, dynamicParameters);
            }
        }
    }
}


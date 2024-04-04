using System;
using Dapper;
using RealEstate_API.DAL;
using RealEstate_API.Dtos.ContactDtos;

namespace RealEstate_API.Repositories.ContactRepository
{
	public class ContactRepository: IContactRepository
    {
        private DataContext _dataContext { get; }
        public ContactRepository(DataContext dataContext)
		{
            _dataContext = dataContext;
		}

        public async Task Create(CreateContactDto createContactDto)
        {
            string query = "insert into Contact(Name,Email,Message,CreatedAt,IsDeleted) values(@name,@email,@meesage,@createdAt,@isDeleted)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@name", createContactDto.Name);
            dynamicParameters.Add("@email", createContactDto.Email);
            dynamicParameters.Add("@meesage", createContactDto.Message);
            dynamicParameters.Add("@createdAt", DateTime.Now);
            dynamicParameters.Add("@isDeleted", false);
            using (var connection = _dataContext.CreateConnection())
            {
                await connection.ExecuteAsync(query,dynamicParameters);
            }
        }

        public async Task<int> Delete(int id)
        {
            string query = "update  contact set IsDeleted=@IsDeleted,DeletedAt=@DeletedAt  where id=@id and IsDeleted!=@IsDeleted ";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@id", id);
            dynamicParameters.Add("@IsDeleted", true);
            dynamicParameters.Add("@DeletedAt", DateTime.Now);
            using (var connection = _dataContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query,dynamicParameters);
            }
        }

        public async Task<List<ResoultContactDto>> GetAllContactAsync()
        {
            string query = "select*from contact where IsDeleted=@IsDeleted";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@IsDeleted", false);
            using(var connection = _dataContext.CreateConnection())
            {
                var datas = await connection.QueryAsync<ResoultContactDto>(query,dynamicParameters);
                return datas.ToList();
            }
            
        }

        public async Task<ResoultContactDto> GetContactById(int id)
        {
            string query = "select*from contact where id=@contactId and IsDeleted=@IsDeleted";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@contactId", id);
            dynamicParameters.Add("@IsDeleted", false);
            using (var connection = _dataContext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<ResoultContactDto>(query,dynamicParameters);
                 
            }
        }

        public async Task<int> Update(UpdateContactDto updateContactDto)
        {
            string query = "update contact set Name=@Name,Email=@Email,Message=@Message,IsResponded=@IsResponded,IsDeleted=@IsDeleted,UpdatedAt=@UpdatedAt,DeletedAt=@DeletedAt";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Name", updateContactDto.Name);
            dynamicParameters.Add("@Email", updateContactDto.Email);
            dynamicParameters.Add("@Message", updateContactDto.Message);
            dynamicParameters.Add("@IsResponded", updateContactDto.IsResponded);
            dynamicParameters.Add("@IsDeleted", updateContactDto.IsDeleted);
            dynamicParameters.Add("@UpdatedAt", DateTime.Now);
            dynamicParameters.Add("@DeletedAt", updateContactDto.IsDeleted?DateTime.Now:null);
            using (var connection = _dataContext.CreateConnection())
            {
                return await connection.ExecuteAsync(query, dynamicParameters);
            }
        }

        public async Task<List<ResoultContactDto>> GetAllContactByAdminAsync()
        {
            string query = "select*from contact";
            using (var connection = _dataContext.CreateConnection())
            {
                var datas = await connection.QueryAsync<ResoultContactDto>(query);
                return datas.ToList();
            }
        }

        public async Task<ResoultContactDto> GetContactByAdmin(int id)
        {
            string query = "select*from contact where id=@contactId";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@contactId", id);
            using (var connection = _dataContext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<ResoultContactDto>(query, dynamicParameters);

            }
        }
    }
}


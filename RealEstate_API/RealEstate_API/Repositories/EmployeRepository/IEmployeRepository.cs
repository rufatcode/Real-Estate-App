using System;
using RealEstate_API.Dtos.EmployeDtos;

namespace RealEstate_API.Repositories.EmployeRepository
{
	public interface IEmployeRepository
	{
		Task CreateEmploye(CreateEmployeDto createEmployeDto);
		Task<int> UpdateEmploye(UpdateEmployeDto updateEmployeDto);
		Task<int> Delete(int id);
		Task<ResoultEmployeDto> GetEmployeById(int id);
		Task<List<ResoultEmployeDto>> GetAll();

	}
}


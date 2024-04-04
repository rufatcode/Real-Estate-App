using System;
using RealEstate_API.Dtos.CategoryDtos;

namespace RealEstate_API.Repositories.CategoryRepository
{
	public interface ICategoryRepository
	{
		Task<List<ResoultCategoryDto>> GetAllCategoryAsync();
		Task<List<ResoultCategoryDto>> GetAllCategoryByAdminAsync();
        Task<ResoultCategoryDto> GetCategoryByAdmin(int id);
        Task<ResoultCategoryDto> GetCategoryById(int id);
        Task Create(CreateCategoryDto createCategoryDto);
		Task<int> Delete(int id);
		Task Update(UpdateCategoryDto updateCategoryDto);
	}
}


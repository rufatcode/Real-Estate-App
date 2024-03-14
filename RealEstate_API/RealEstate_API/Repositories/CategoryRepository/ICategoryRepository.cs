using System;
using RealEstate_API.Dtos.CategoryDtos;

namespace RealEstate_API.Repositories.CategoryRepository
{
	public interface ICategoryRepository
	{
		Task<List<ResoultCategoryDto>> GetAllCategoryAsync();
		Task<ResoultCategoryDto> GetCategoryById(int id);
		Task Create(CreateCategoryDto createCategoryDto);
		Task Delete(int id);
		Task Update(UpdateCategoryDto updateCategoryDto);
	}
}


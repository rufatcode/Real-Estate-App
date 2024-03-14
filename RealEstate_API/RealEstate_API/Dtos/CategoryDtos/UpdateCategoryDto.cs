using System;
namespace RealEstate_API.Dtos.CategoryDtos
{
	public class UpdateCategoryDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public UpdateCategoryDto()
		{
		}
	}
}


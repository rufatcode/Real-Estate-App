using System;
namespace RealEstate_API.Dtos.EmployeDtos
{
	public class CreateEmployeDto
	{
		public string Name { get; set; }
		public string Position { get; set; }
		public string? ImageUrl { get; set; }
		public string PhoneNumber { get; set; }
		public string? PublicId { get; set; }
		public IFormFile Image { get; set; }
		public CreateEmployeDto()
		{
		}
	}
}


using System;
namespace RealEstate_UI.ViewModels.EmployeeVM
{
	public class UpdateEmployeeVM
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string? ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
        public string? PublicId { get; set; }
        public IFormFile? Image { get; set; }
        public UpdateEmployeeVM()
		{
		}
	}
}


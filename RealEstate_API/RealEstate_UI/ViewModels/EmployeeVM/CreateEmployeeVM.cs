﻿using System;
namespace RealEstate_UI.ViewModels.EmployeeVM
{
	public class CreateEmployeeVM
	{
        public string Name { get; set; }
        public string Position { get; set; }
        public string? ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string? PublicId { get; set; }
        public IFormFile Image { get; set; }
        public CreateEmployeeVM()
		{
		}
	}
}


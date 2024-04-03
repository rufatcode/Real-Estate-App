using System;
namespace RealEstate_API.Dtos.EmployeDtos
{
	public class ResoultEmployeDto:BaseDto
	{
        public string Name { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string PublicId { get; set; }
        public ResoultEmployeDto()
		{
		}
	}
}


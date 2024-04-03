using System;
namespace RealEstate_API.Dtos.ContactDtos
{
	public class ResoultContactDto:BaseDto
	{
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsResponded { get; set; }
        public ResoultContactDto()
		{
		}
	}
}


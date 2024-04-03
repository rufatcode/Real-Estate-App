using System;
namespace RealEstate_API.Dtos.ContactDtos
{
	public class UpdateContactDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
		public bool IsResponded { get; set; }
		public bool IsDeleted { get; set; }
        public UpdateContactDto()
		{
		}
	}
}


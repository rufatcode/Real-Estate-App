using System;
namespace RealEstate_API.Dtos.SettingDtos
{
	public class UpdateSettingDto
	{
		public int Id { get; set; }
		public string Key { get; set; }
        public string Value { get; set; }
		public bool IsDeleted { get; set; }
		public UpdateSettingDto()
		{
		}
	}
}


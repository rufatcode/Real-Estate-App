using System;
namespace RealEstate_UI.ViewModels.SettingVM
{
	public class UpdateSettingVM
	{
        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        public UpdateSettingVM()
		{
		}
	}
}


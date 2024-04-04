using System;
using RealEstate_UI.ViewModels.SettingVM;

namespace RealEstate_UI.ViewModels
{
	public class ContactVM
	{
        public List<ResoultSettingVM> SettingVMs { get; set; }
        public ContactVM()
		{
            SettingVMs = new();
		}
	}
}


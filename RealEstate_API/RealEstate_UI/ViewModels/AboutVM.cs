using System;
using RealEstate_UI.ViewModels.EmployeeVM;
using RealEstate_UI.ViewModels.SettingVM;

namespace RealEstate_UI.ViewModels
{
	public class AboutVM
	{
		public List<ResoultSettingVM> SettingVMs { get; set; }
		public List<ResoultEmployeeVM> EmployeeVMs { get; set; }
		public AboutVM()
		{
			SettingVMs = new();
            EmployeeVMs = new();
        }
	}
}


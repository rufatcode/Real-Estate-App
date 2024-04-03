using System;
using RealEstate_UI.ViewModels.SettingVM;

namespace RealEstate_UI.ViewModels
{
	public class HomeVM
	{
		public List<ResoultSettingVM> SettingVMs { get; set; }
		public HomeVM()
		{
			SettingVMs = new();
		}
	}
}


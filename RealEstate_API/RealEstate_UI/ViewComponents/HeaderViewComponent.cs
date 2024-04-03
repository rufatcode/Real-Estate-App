using System;
using Microsoft.AspNetCore.Mvc;
using RealEstate_UI.ViewModels.SettingVM;

namespace RealEstate_UI.ViewComponents
{
	public class HeaderViewComponent:ViewComponent
	{
		HttpClient _httpClient = new();

        public HeaderViewComponent()
		{

        }
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}


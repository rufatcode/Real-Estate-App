using System;
using Microsoft.AspNetCore.Mvc;
using RealEstate_UI.ViewModels.SettingVM;

namespace RealEstate_UI.ViewComponents
{
	public class FooterViewComponent: ViewComponent
    {
		HttpClient _httpClient = new();
		public FooterViewComponent()
		{
            _httpClient.BaseAddress = new Uri("https://localhost:7222/api/");
        }
		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<ResoultSettingVM> datas = await _httpClient.GetFromJsonAsync<List<ResoultSettingVM>>($"Setting");
			return View(await Task.FromResult(datas));
		}
	}
}


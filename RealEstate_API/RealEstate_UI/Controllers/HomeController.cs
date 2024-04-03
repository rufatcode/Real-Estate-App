using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate_UI.ViewModels;
using RealEstate_UI.ViewModels.SettingVM;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private readonly HomeVM _homeVM;
        private readonly HttpClient _httpClient;
        public HomeController()
        {
            _homeVM = new();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7222/api/") };
        }
       
        public async Task<IActionResult> Index()
        {
            _homeVM.SettingVMs = await _httpClient.GetFromJsonAsync<List<ResoultSettingVM>>("Setting");

            return View(_homeVM);
        }
    }
}


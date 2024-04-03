using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate_UI.ViewModels;
using RealEstate_UI.ViewModels.EmployeeVM;
using RealEstate_UI.ViewModels.SettingVM;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly AboutVM _aboutVM;
        private readonly HttpClient _httpClient;
        public AboutController()
        {
            _aboutVM = new();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7222/api/") };
        }
        // GET: /<controller>/

        public async Task<IActionResult> Index()
        {
            _aboutVM.SettingVMs = await _httpClient.GetFromJsonAsync<List<ResoultSettingVM>>("Setting");
            _aboutVM.EmployeeVMs = await _httpClient.GetFromJsonAsync<List<ResoultEmployeeVM>>("Employe");
            return View(_aboutVM);
        }
    }
}


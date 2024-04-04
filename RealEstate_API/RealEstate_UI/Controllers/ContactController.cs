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
    public class ContactController : Controller
    {
        private readonly ContactVM _contactVM;
        private readonly HttpClient _httpClient;
        public ContactController()
        {
            _contactVM = new();
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7222/api/") };
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            _contactVM.SettingVMs = await _httpClient.GetFromJsonAsync<List<ResoultSettingVM>>("Setting");
            return View(_contactVM);
        }
        public async Task<IActionResult> ContactRequest(string name,string email,string message)
        {
            ContactResuqestVM contact = new() { Name = name, Message = message, Email = email };
            var resoult = await _httpClient.PostAsJsonAsync<ContactResuqestVM>("Contact", contact);
            if ((int)resoult.StatusCode!=(int)StatusCodes.Status200OK)
            {
                TempData["Info"] = "Something went wrong";
                return RedirectToAction("Index");
            }
            TempData["Info"] = "Request successfully sended";
            return RedirectToAction("Index");
        }
    }
}


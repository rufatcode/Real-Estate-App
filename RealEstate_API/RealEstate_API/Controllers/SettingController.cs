using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.SettingDtos;
using RealEstate_API.Repositories.SettingRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    public class SettingController : Controller
    {
        private readonly ISettingRepository _settingRepository;
        public SettingController(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }
        [HttpPost]
        public async Task<IActionResult>Post(CreateSettingDto createSettingDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _settingRepository.Create(createSettingDto);
            return Ok($"{createSettingDto.Key} seuccessfully added");
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            int resoult = await _settingRepository.Delete(Id);
            if (resoult == 0) return BadRequest();
            return Ok($"data successfully deleted");

        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var datas = await _settingRepository.Get();
            if (datas.Count == 0) return BadRequest("empty data list");
            return Ok(datas);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var data = await _settingRepository.Get(Id);
            if (data==null) return NotFound("data is not exist");
            return Ok(data);
        }
        [HttpGet("GetByAdmin")]
        public async Task<IActionResult> GetByAdmin()
        {
            var datas = await _settingRepository.GetByAdmin();
            if (datas.Count == 0) return BadRequest("empty data list");
            return Ok(datas);
        }
        [HttpGet("GetByAdmin/{Id}")]
        public async Task<IActionResult> GetByAdmin(int Id)
        {
            var data = await _settingRepository.GetByAdmin(Id);
            if (data == null) return NotFound("data is not exist");
            return Ok(data);
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult>Put(UpdateSettingDto updateSettingDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            int resoult = await _settingRepository.Update(updateSettingDto);
            if (resoult == 0) return BadRequest();
            return Ok($"{updateSettingDto.Key} successfully updated");
        }
    }
}


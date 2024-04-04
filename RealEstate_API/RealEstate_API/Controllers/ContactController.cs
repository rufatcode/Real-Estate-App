using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.DAL;
using RealEstate_API.Dtos.ContactDtos;
using RealEstate_API.Repositories.ContactRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public async Task<IActionResult>Post([FromBody]CreateContactDto createContactDto)
        {
            if (!ModelState.IsValid) return BadRequest("Something went wrong");
            await _contactRepository.Create(createContactDto);
            return Ok($"{createContactDto.Name} your session successfully sended");
        }
        [HttpDelete]
        public async Task<IActionResult>Delete(int id)
        {
            int resoult =await _contactRepository.Delete(id);
            if (resoult == 0) return NotFound();
            return Ok("data successfully deleted");
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ResoultContactDto> datas = await _contactRepository.GetAllContactAsync();
            if (datas.Count == 0) return NotFound("emtpy data list");
            return Ok(datas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            ResoultContactDto data = await _contactRepository.GetContactById(id);
            if (data == null) return NotFound("data is not exist");            
            return Ok(data);
        }
        [HttpGet("GetByAdmin")]
        public async Task<IActionResult> GetByAdmin()
        {
            List<ResoultContactDto> datas = await _contactRepository.GetAllContactByAdminAsync();
            if (datas.Count == 0) return NotFound("emtpy data list");
            return Ok(datas);
        }
        [HttpGet("GetByAdmin/{id}")]
        public async Task<IActionResult> GetByAdmin(int id)
        {
            ResoultContactDto data = await _contactRepository.GetContactByAdmin(id);
            if (data == null) return NotFound("data is not exist");
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult>Put(UpdateContactDto updateContactDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            int resoult = await _contactRepository.Update(updateContactDto);
            if (resoult == 0) return BadRequest();
            return Ok($"{updateContactDto.Name} successfully updated");
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.EmployeDtos;
using RealEstate_API.Repositories.EmployeRepository;
using RealEstate_API.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    public class EmployeController : Controller
    {
        private readonly IEmployeRepository _employeRepository;
        private readonly IPhotoAccessor _photoAccessor;
        private readonly IFileService _fileService;
        public EmployeController(IEmployeRepository employeRepository,IPhotoAccessor photoAccessor,IFileService fileService)
        {
            _employeRepository = employeRepository;
            _photoAccessor = photoAccessor;
            _fileService = fileService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeDto createEmployeDto )
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            else if (! _fileService.IsImage(createEmployeDto.Image)||!_fileService.LengthIsSuitable(createEmployeDto.Image,1000)) return BadRequest("invalid image");
            createEmployeDto.ImageUrl = null;
            createEmployeDto.PublicId = null;
            ImageUploadResult resoult =await _photoAccessor.AddPhoto(createEmployeDto.Image);
            createEmployeDto.ImageUrl = resoult.SecureUrl.ToString();
            createEmployeDto.PublicId = resoult.PublicId;
            await _employeRepository.CreateEmploye(createEmployeDto);
            return Ok("Data successfully added");
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var datas = await _employeRepository.GetAll();
            if (datas.Count == 0) return NotFound("empty data list");
            
            return Ok(datas);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var data = await _employeRepository.GetEmployeById(Id);
            if (data == null) return NotFound("data is not exist");

            return Ok(data);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var resoult = await _employeRepository.Delete(id);
            if (resoult == 0) return NotFound();
            return Ok("data successfully deleted");
        }
        [HttpPut("{Id}")]
        public async Task<IActionResult>Put(UpdateEmployeDto updateEmployeDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            else if (updateEmployeDto.Image != null && (!_fileService.IsImage(updateEmployeDto.Image) || !_fileService.LengthIsSuitable(updateEmployeDto.Image, 1000)))return BadRequest("invalid Image") ;
            updateEmployeDto.ImageUrl = null;
            updateEmployeDto.PublicId = null;
            string oldPublicId = string.Empty;
            if (updateEmployeDto.Image!=null)
            {
                var data = await _employeRepository.GetEmployeById(updateEmployeDto.Id);
                oldPublicId = data.PublicId;
                ImageUploadResult imageResoult =await _photoAccessor.AddPhoto(updateEmployeDto.Image);
                updateEmployeDto.ImageUrl = imageResoult.SecureUrl.ToString();
                updateEmployeDto.PublicId = imageResoult.PublicId;
            }
            var resoult = await _employeRepository.UpdateEmploye(updateEmployeDto);
            if (resoult == 0) return BadRequest();
            if (oldPublicId != "") await _photoAccessor.DeletePhoto(oldPublicId);
            return Ok("data successfully updated");
        }
    }
}


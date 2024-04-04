using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RealEstate_API.Dtos.CategoryDtos;
using RealEstate_API.Repositories.CategoryRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RealEstate_API.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var resoult =await _categoryRepository.GetAllCategoryAsync();
            return Ok(resoult);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            return Ok(await _categoryRepository.GetCategoryById(id));
        }
        [HttpGet("GetByAdmin")]
        public async Task<IActionResult> GetByAdmin()
        {
            var resoult = await _categoryRepository.GetAllCategoryByAdminAsync();
            return Ok(resoult);
        }
        [HttpGet("GetByAdmin/{id}")]
        public async Task<IActionResult> GetByAdmin(int id)
        {
            return Ok(await _categoryRepository.GetCategoryByAdmin(id));
        }
        [HttpPost]
        public async Task<IActionResult>Post(CreateCategoryDto createCategoryDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _categoryRepository.Create(createCategoryDto);
            return Ok($"{createCategoryDto.Name} successfully created");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
           var resoult= await _categoryRepository.Delete(id);
            if (resoult == 0) return BadRequest();
            return Ok("Deleted successfully finshed");
        }
        [HttpPut]
        public async Task<IActionResult>Put(UpdateCategoryDto updateCategoryDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _categoryRepository.Update(updateCategoryDto);
            return Ok($"{updateCategoryDto.Name} successfully updated");
        }
    }
}


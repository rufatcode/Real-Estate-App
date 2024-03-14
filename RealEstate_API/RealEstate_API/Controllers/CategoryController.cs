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
        [HttpPost]
        public async Task<IActionResult>Post(CreateCategoryDto createCategoryDto)
        {
            await _categoryRepository.Create(createCategoryDto);
            return Ok($"{createCategoryDto.Name} successfully created");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            await _categoryRepository.Delete(id);
            return Ok("Deleted successfully finshed");
        }
        [HttpPut]
        public async Task<IActionResult>Put(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryRepository.Update(updateCategoryDto);
            return Ok($"{updateCategoryDto.Name} successfully updated");
        }
    }
}


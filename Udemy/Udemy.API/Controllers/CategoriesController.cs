using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Udemy.BUSINESS.Services.Interfaces;
using Udemy.BUSINESS.DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc.Infrastructure;
namespace Udemy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IValidator<CategoryCreateDto> _validator;
        private readonly IValidator<CategoryUpdateDto> _validatorUpdate;
        public CategoriesController(ICategoryService service, IValidator<CategoryCreateDto> validator, IValidator<CategoryUpdateDto> validatorUpdate)
        {
            _service = service;
            _validator = validator;
            _validatorUpdate = validatorUpdate;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto createBrandDto)
        {
            var validationResult = _validator.Validate(createBrandDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _service.Create(createBrandDto);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpGet("RecycleBin")]
        public async Task<IActionResult> RecycleBin(bool Restore)
        {
            var brands = await _service.RecycleBin();

            if (Restore)
            {
                await _service.Restore();
            }
            return StatusCode(StatusCodes.Status200OK, brands);

        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = _service.GetAllAsync();
            return StatusCode(StatusCodes.Status200OK, categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            CategoryGetDto categoryGetDto = await _service.GetById(id);
            return StatusCode(StatusCodes.Status200OK,categoryGetDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await _service.DeleteAll();
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] CategoryUpdateDto updateBrandDto)
        {
            var validationResult = _validatorUpdate.Validate(updateBrandDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _service.Update(updateBrandDto);
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}

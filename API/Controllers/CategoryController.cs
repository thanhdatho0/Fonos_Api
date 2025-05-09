using DataAcces.EFCore.Mappers;
using Domain.DTOs.BookDtos;
using Domain.DTOs.CategoryDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var categories = await _unitOfWork.Categories.GetAll();
                return Ok(categories.Select(b => b.ToCategoryDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var category = categoryCreateDto.ToCategoryFromCreateDto();
                try
                {
                    _unitOfWork.Categories.Add(category);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

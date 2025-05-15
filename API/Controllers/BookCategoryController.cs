using DataAcces.EFCore.Mappers;
using Domain.DTOs.BookCategoryDtos;
using Domain.DTOs.BookDtos;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCategoryController(IUnitOfWork unitOfWork) : ControllerBase
    {
            private readonly IUnitOfWork _unitOfWork = unitOfWork;

            [HttpGet]
            public async Task<IActionResult> GetAll([FromQuery] Guid? bookId = null, Guid? categoryId = null)
            {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                IEnumerable<BookCategory> bookCategories;

                if (bookId == null && categoryId == null)
                {
                    bookCategories = await _unitOfWork.BookCategories.GetAll();
                }
                else
                {
                    bookCategories = await _unitOfWork.BookCategories.Find(b =>
                        (!bookId.HasValue || b.BookId == bookId) &&
                        (!categoryId.HasValue || b.CategoryId == categoryId));
                }

                return Ok(bookCategories.Select(b => b.ToBookCategoryDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

            [HttpPost]
            public async Task<IActionResult> Create(BookCategoryCreateDto bookCategoryCreateDto)
            {
                try
                {
                    if (!ModelState.IsValid) return BadRequest(ModelState);
                    var bookCategory = bookCategoryCreateDto.ToBookCategoryFromCreateDto();
                    try
                    {
                        _unitOfWork.BookCategories.Add(bookCategory);
                        await _unitOfWork.Complete();
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, ex.Message);
                    }
                    return Ok(bookCategory);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        
    }
}

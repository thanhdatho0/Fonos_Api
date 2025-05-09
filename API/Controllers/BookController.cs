using DataAcces.EFCore.Mappers;
using Domain.DTOs.BookDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var books = await _unitOfWork.Books.GetAll();
                return Ok(books.Select(b => b.ToBookDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateDto bookCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var books = bookCreateDto.ToBookFromCreateDto();
                try
                {
                    _unitOfWork.Books.Add(books);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

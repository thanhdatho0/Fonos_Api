
using DataAcces.EFCore.Mappers;
using DataAcces.EFCore.Repositories;
using Domain.DTOs.AuthorDtos;
using Domain.DTOs.BookAuthorDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAuthorController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Guid? bookId = null)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var bookAuthors = bookId != null
                    ? await _unitOfWork.BookAuthors.Find(b => b.BookId == bookId)
                    : await _unitOfWork.BookAuthors.GetAll();
                return Ok(bookAuthors.Select(b => b.ToBookAuthorDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("same-author")]
        public async Task<IActionResult> GetBooksSameAuthor([FromQuery] Guid authorId, Guid? bookId, int? limit)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var books = bookId != null 
                    ? await _unitOfWork.BookAuthors
                        .Find(b => b.AuthorId == authorId && b.BookId != bookId)
                    : await _unitOfWork.BookAuthors.Find(b => b.AuthorId == authorId);
                if (limit.HasValue)
                    books = books.Take(limit.Value);
                return Ok(books.Select(b => b.ToBookAuthorDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookAuthorCreateDto bookAuthorCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var bookAuthor = bookAuthorCreateDto.ToBookAuthorFromCreateDto();
                try
                {
                    _unitOfWork.BookAuthors.Add(bookAuthor);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(bookAuthor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

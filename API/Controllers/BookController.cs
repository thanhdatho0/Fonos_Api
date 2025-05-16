using DataAcces.EFCore.Mappers;
using Domain.DTOs.BookDtos;
using Domain.Interfaces;
using Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] PaginationParams? pagination)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);

                var books = await _unitOfWork.Books.GetAll(pagination);
                var total = await _unitOfWork.Books.CountAsync();

                if (pagination == null || pagination.PageNumber <= 0 || pagination.PageSize <= 0)
                {
                    return Ok(books.Select(b => b.ToBookDto()));
                }

                var result = new PageResult<BookDto>
                {
                    Items = [.. books.Select(b => b.ToBookDto())],
                    TotalCount = total,
                    PageNumber = pagination.PageNumber,
                    PageSize = pagination.PageSize
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("mobile-option")]
        public async Task<IActionResult> GetAllForMobile([FromQuery] int? limit = null)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var books = await _unitOfWork.Books.GetAll();

                var result = books.Select(b => b.ToBookDto());

                if (limit.HasValue)
                {
                    result = result.Take(limit.Value);
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var books = await _unitOfWork.Books.GetById(id);
                var response = books?.ToBookDetailDto();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("new")]
        public async Task<IActionResult> GetNewBooks([FromQuery] int? limit)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var audiobook = await _unitOfWork.Books.GetNewBook();
                if (limit.HasValue)
                    audiobook = audiobook.Take(limit.Value);
                return Ok(audiobook.Select(a => a!.ToBookDetailDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("top-rating")]
        public async Task<IActionResult> GetTopRatingBooks([FromQuery] int? limit)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var audiobooks = await _unitOfWork.Books.GetAll();
                var topRatingBooks = audiobooks.Select(a => a.ToBookDetailDto());
                var response = limit != null
                    ? [.. topRatingBooks
                        .OrderByDescending(a => a.Rating)
                        .Take(limit.Value)]
                    : topRatingBooks
                        .OrderByDescending(a => a.Rating)
                        .ToList();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("same-publisher")]
        public async Task<IActionResult> GetSamePublisherBooks([FromQuery] Guid publisherId, Guid? bookId, int? limit)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var audiobooks = bookId != null 
                    ? await _unitOfWork.Books
                        .Find(b => b.PublisherId == publisherId && b.BookId != bookId)
                    : await _unitOfWork.Books
                        .Find(b => b.PublisherId == publisherId);
                if (limit.HasValue)
                    audiobooks = audiobooks.Take(limit.Value);
                return Ok(audiobooks.Select(a => a!.ToBookDto()));
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
                var book = bookCreateDto.ToBookFromCreateDto();
                try
                {
                    _unitOfWork.Books.Add(book);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(book.ToBookDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, BookUpdateDto bookUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var book = await _unitOfWork.Books.GetById(id);
                if (book == null) return StatusCode(400, "Sách không tồn tại");
                try
                {
                    book.ToBookFromUpdateDto(bookUpdateDto);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(book.ToBookDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

using DataAcces.EFCore.Mappers;
using DataAcces.EFCore.Repositories;
using Domain.DTOs.RatingDtos;
using Domain.DTOs.UserFavoriteDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var ratings = await _unitOfWork.Ratings.GetAll();
                return Ok(ratings.Select(b => b.ToRatingDto()));
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
                var rating = await _unitOfWork.Ratings.GetById(id);
                if (rating == null) return NotFound("Download data not found");
                return Ok(rating.ToRatingDeatailDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("book-ratings")]
        public async Task<IActionResult> GetRatingsByBookId([FromQuery] Guid bookId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var ratings = await _unitOfWork.Ratings.Find(r => r.BookId == bookId);
                return Ok(ratings.Select(b => b.ToRatingOfBookDto()).OrderByDescending(b => b.CreatedDate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(RatingCreateDto ratingCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var rating = ratingCreateDto.ToRatingFromCreateDto();
                try
                {
                    _unitOfWork.Ratings.Add(rating);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(rating.ToRatingDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

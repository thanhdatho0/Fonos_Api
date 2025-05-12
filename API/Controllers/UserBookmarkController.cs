using DataAcces.EFCore.Mappers;
using DataAcces.EFCore.Repositories;
using Domain.DTOs.UserBookmarkDtos;
using Domain.DTOs.UserPlaylistDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBookmarkController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userBookmarks = await _unitOfWork.UserBookmarks.GetAll();
                return Ok(userBookmarks.Select(b => b.ToUserBookmarkDto()));
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
                var userBookmark = await _unitOfWork.UserBookmarks.GetById(id);
                if (userBookmark == null) return NotFound("Download data not found");
                return Ok(userBookmark.ToUserBookmarkDetailDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserBookmarkCreateDto userBookmarkCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userBookmark = userBookmarkCreateDto.ToUserBookmarkCreateDto();
                try
                {
                    _unitOfWork.UserBookmarks.Add(userBookmark);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(userBookmark.ToUserBookmarkDetailDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

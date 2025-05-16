using DataAcces.EFCore.Mappers;
using DataAcces.EFCore.Repositories;
using Domain.DTOs.UserBookmarkDtos;
using Domain.DTOs.UserFavoriteDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavoriteController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? userId = null)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userFavorites = userId == null 
                    ? await _unitOfWork.UserFavorites.GetAll()
                    : await _unitOfWork.UserFavorites.Find(uf => uf.AppUserId == userId);
                return Ok(userFavorites.Select(b => b.ToUserFavoriteDto()));
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
                var userFavorite = await _unitOfWork.UserFavorites.GetById(id);
                if (userFavorite == null) return NotFound("Download data not found");
                return Ok(userFavorite.ToUserFavoriteDetailDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserFavoriteCreateDto userFavoriteCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userFavorite = userFavoriteCreateDto.ToUserFavoriteFromCreateDto();
                try
                {
                    _unitOfWork.UserFavorites.Add(userFavorite);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(userFavorite.ToUserFavoriteDetailDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userFavorite = await _unitOfWork.UserFavorites.GetById(id);
                if (userFavorite == null) return NotFound("Download data not found");
                _unitOfWork.UserFavorites.Remove(userFavorite);
                await _unitOfWork.Complete();
                return Ok(userFavorite.ToUserFavoriteDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

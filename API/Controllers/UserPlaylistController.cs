using DataAcces.EFCore.Mappers;
using DataAcces.EFCore.Repositories;
using Domain.DTOs.DownloadDtos;
using Domain.DTOs.UserPlaylistDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPlaylistController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userPlaylists = await _unitOfWork.UserPlaylists.GetAll();
                return Ok(userPlaylists.Select(b => b.ToUserPlaylistDto()));
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
                var userPlaylist = await _unitOfWork.UserPlaylists.GetById(id);
                if (userPlaylist == null) return NotFound("Download data not found");
                return Ok(userPlaylist.ToUserPlaylistDetailDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserPlaylistCreateDto userPlaylistCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userPlaylist = userPlaylistCreateDto.ToUserPlaylistCreateDto();
                try
                {
                    _unitOfWork.UserPlaylists.Add(userPlaylist);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(userPlaylist.ToUserPlaylistDetailDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

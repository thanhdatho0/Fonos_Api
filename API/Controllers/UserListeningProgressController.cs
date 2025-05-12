using DataAcces.EFCore.Mappers;
using DataAcces.EFCore.Repositories;
using Domain.DTOs.UserListeningProgressDtos;
using Domain.DTOs.UserPlaylistDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserListeningProgressController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userListeningProgresses = await _unitOfWork.UserListeningProgresses.GetAll();
                return Ok(userListeningProgresses.Select(b => b.ToUserListeningProgressDto()));
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
                var userListeningProgress = await _unitOfWork.UserListeningProgresses.GetById(id);
                if (userListeningProgress == null) return NotFound("Download data not found");
                return Ok(userListeningProgress.ToUserListeningProgressDetailDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserListeningProgressCreateDto userListeningProgressCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var userListeningProgress = userListeningProgressCreateDto.ToUserListeningProgressFromCreateDto();
                try
                {
                    _unitOfWork.UserListeningProgresses.Add(userListeningProgress);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(userListeningProgress.ToUserListeningProgressDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

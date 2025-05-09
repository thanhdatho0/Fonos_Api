using DataAcces.EFCore.Mappers;
using DataAcces.EFCore.Repositories;
using Domain.DTOs.AudiobookDtos;
using Domain.DTOs.AuthorDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudiobookController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var audiobooks = await _unitOfWork.Audiobooks.GetAll();
                return Ok(audiobooks.Select(b => b.ToAudiobookDto()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AudiobookCreateDto audiobookCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var audiobook = audiobookCreateDto.ToAudiobookFromCreateDto();
                try
                {
                    _unitOfWork.Audiobooks.Add(audiobook);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(audiobook);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

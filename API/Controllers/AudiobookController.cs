using System.Data;
using DataAcces.EFCore.Mappers;
using Domain.DTOs.AudiobookDtos;
using Domain.Interfaces;
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

        [HttpGet("get-book")]
        public async Task<IActionResult> GetById([FromQuery] Guid bookId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var audiobook = await _unitOfWork.Audiobooks.Find(ab => ab.BookId == bookId);
                if (audiobook == null) return NotFound("Audiobook not found");
                return Ok(audiobook.Select(a => a.ToAudiobookDto()).First());
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, AudiobookUpdateDto audiobookUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var audiobook = await _unitOfWork.Audiobooks.GetById(id);
                if (audiobook == null) return NotFound("Audiobook not found");
                try
                {
                    audiobook.ToAudiobookFromUpdateDto(audiobookUpdateDto);
                    await _unitOfWork.Complete();
                    return Ok(audiobook.ToAudiobookDto());
                }
                catch (Exception ex)
                {
                    return StatusCode(500, "Đã có lỗi xảy ra: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

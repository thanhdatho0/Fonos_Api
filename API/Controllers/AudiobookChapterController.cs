using DataAcces.EFCore.Mappers;
using DataAcces.EFCore.Repositories;
using Domain.DTOs.AudiobookChapterDtos;
using Domain.DTOs.AudiobookDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AudiobookChapterController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Guid? audioBookId = null)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var audiobookChapters = audioBookId != null 
                    ? await _unitOfWork.AudiobookChapters.Find(a => a.AudiobookId == audioBookId)
                    : await _unitOfWork.AudiobookChapters.GetAll();
                return Ok(audiobookChapters.Select(b => b.ToAudiobookChapter()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(AudiobookChapterCreateDto audiobookChapterCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var audiobookChapter = audiobookChapterCreateDto.ToAudiobookChapterFromCreateDto();
                try
                {
                    _unitOfWork.AudiobookChapters.Add(audiobookChapter);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(audiobookChapter);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, AudiobookChapterUpdateDto audiobookChapterUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var audiobookChapters = await _unitOfWork.AudiobookChapters.GetById(id);
                if (audiobookChapters == null) return StatusCode(400, "Không tìm thấy chapter");
                try
                {
                    audiobookChapters.ToAudiobookChapterFromUpdateDto(audiobookChapterUpdateDto);
                    await _unitOfWork.Complete();
                    return Ok(audiobookChapters.ToAudiobookChapter());
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Đã có lỗi xảy ra: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

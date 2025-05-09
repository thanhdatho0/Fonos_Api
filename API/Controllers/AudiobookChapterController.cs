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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var audiobookChapters = await _unitOfWork.AudiobookChapters.GetAll();
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
    }
}

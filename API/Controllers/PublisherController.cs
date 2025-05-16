using DataAcces.EFCore.Mappers;
using Domain.DTOs.BookDtos;
using Domain.DTOs.PublisherDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var publishers = await _unitOfWork.Publishers.GetAll();
                return Ok(publishers.Select(b => b.ToPublisherDto()));
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
                var publishers = await _unitOfWork.Publishers.GetById(id);
                if (publishers == null) return StatusCode(400, "Không tìm thấy thông tin Nhà sản xuất");
                return Ok(publishers.ToPublisherDto());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PublisherCreateDto publisherCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var publisher = publisherCreateDto.ToPublisherFromCreateDto();
                try
                {
                    _unitOfWork.Publishers.Add(publisher);
                    await _unitOfWork.Complete();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                return Ok(publisher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

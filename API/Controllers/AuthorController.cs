using DataAcces.EFCore.Mappers;
using DataAcces.EFCore.Repositories;
using Domain.DTOs.AuthorDtos;
using Domain.DTOs.BookCategoryDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IUnitOfWork unitOfWork) : ControllerBase
    {
            private readonly IUnitOfWork _unitOfWork = unitOfWork;

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                try
                {
                    if (!ModelState.IsValid) return BadRequest(ModelState);
                    var authors = await _unitOfWork.Authors.GetAll();
                    return Ok(authors.Select(b => b.ToAuthorDto()));
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            [HttpPost]
            public async Task<IActionResult> Create(AuthorCreateDto authorCreateDto)
            {
                try
                {
                    if (!ModelState.IsValid) return BadRequest(ModelState);
                    var author = authorCreateDto.ToAuthorFromCreateDto();
                    try
                    {
                        _unitOfWork.Authors.Add(author);
                        await _unitOfWork.Complete();
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, ex.Message);
                    }
                    return Ok(author);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        
    }
}

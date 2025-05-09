using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.AuthorDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class AuthorMappers
    {
        public static AuthorDto ToAuthorDto(this Author author)
        {
            return new AuthorDto
            {
                AuthorId = author.AuthorId,
                AuthorName = author.AuthorName,
                Biography = author.Biography,
                BirthDate = author.BirthDate,
                DeathDate = author.DeathDate,
                Nationality = author.Nationality,
                ImageUrl = author.ImageUrl,
            };
        }

        public static Author ToAuthorFromCreateDto(this AuthorCreateDto authorCreateDto)
        {
            return new Author
            {
                AuthorName = authorCreateDto.AuthorName,
                Biography = authorCreateDto.Biography,
                BirthDate = authorCreateDto.BirthDate,
                DeathDate = authorCreateDto.DeathDate,
                Nationality = authorCreateDto.Nationality,
                ImageUrl = authorCreateDto.ImageUrl,
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.PublisherDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class PublisherMappers
    {
        public static Publisher ToPublisherFromCreateDto(this PublisherCreateDto publisherCreateDto)
        {
            return new Publisher
            {
                PublisherName = publisherCreateDto.PublisherName,
                Description = publisherCreateDto.Description,
                Website = publisherCreateDto.Website,
                FoundedYear = publisherCreateDto.FoundedYear,
            };
        }

        public static PublisherDto ToPublisherDto(this Publisher publisher)
        {
            return new PublisherDto
            {
                PublisherId = publisher.PublisherId,
                PublisherName = publisher.PublisherName,
                Description = publisher.Description,
                Website = publisher.Website,
                FoundedYear = publisher.FoundedYear,
            };
        }
    }
}

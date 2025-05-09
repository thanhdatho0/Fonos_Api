using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.CategoryDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
                IsActive = category.IsActive,
                DisplayOrder = category.DisplayOrder,
                ParentCategoryId = category.ParentCategoryId,
            };
        }

        public static Category ToCategoryFromCreateDto(this CategoryCreateDto categoryCreateDto)
        {
            return new Category
            {
                CategoryName = categoryCreateDto.CategoryName,
                Description = categoryCreateDto.Description,
                ImageUrl = categoryCreateDto.ImageUrl,
                IsActive = categoryCreateDto.IsActive,
                DisplayOrder = categoryCreateDto.DisplayOrder,
                ParentCategoryId = categoryCreateDto.ParentCategoryId,
            };
        }
    }
}

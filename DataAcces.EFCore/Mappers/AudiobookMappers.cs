using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.EFCore.Utils;
using Domain.DTOs.AudiobookDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class AudiobookMappers
    {
        public static AudiobookDto ToAudiobookDto(this Audiobook audiobook)
        {
            return new AudiobookDto
            {
                AudiobookId = audiobook.AudiobookId,
                BookId = audiobook.BookId,
                Duration = AppUtils.CalculateDurationToString(audiobook.Duration ?? 0),
                FileSize = audiobook.FileSize,
                AudioQuality = audiobook.AudioQuality,
                ReleaseDate = audiobook.ReleaseDate,
                IsComplete = audiobook.IsComplete,
                TotalChapters = audiobook.TotalChapters,
            };
        }

        public static AudiobookDetailDto ToAudiobookDetailDto(this Audiobook audiobook)
        {
            return new AudiobookDetailDto
            {
                AudiobookId = audiobook.AudiobookId,
                BookId = audiobook.BookId,
                Duration = AppUtils.CalculateDurationToString(audiobook.Duration ?? 0),
                FileSize = audiobook.FileSize,
                AudioQuality = audiobook.AudioQuality,
                ReleaseDate = audiobook.ReleaseDate,
                IsComplete = audiobook.IsComplete,
                TotalChapters = audiobook.TotalChapters,
                Chapters = audiobook.Chapters.Select(c => c.ToAudiobookChapter())
            };
        }

        public static Audiobook ToAudiobookFromCreateDto(this AudiobookCreateDto audiobookCreateDto)
        {
            return new Audiobook
            {
                BookId = audiobookCreateDto.BookId,
                Duration = 0,
                FileSize = audiobookCreateDto.FileSize,
                AudioQuality = audiobookCreateDto.AudioQuality,
                ReleaseDate = audiobookCreateDto.ReleaseDate,
                IsComplete = audiobookCreateDto.IsComplete,
                TotalChapters = 0,
            };
        }

        public static void ToAudiobookFromUpdateDto(this Audiobook audiobook, AudiobookUpdateDto audiobookUpdateDto)
        {
            audiobook.BookId = audiobookUpdateDto.BookId;
            audiobook.FileSize = audiobookUpdateDto.FileSize;
            audiobook.AudioQuality = audiobookUpdateDto.AudioQuality;
            audiobook.ReleaseDate = audiobookUpdateDto.ReleaseDate;
            audiobook.IsComplete = audiobookUpdateDto.IsComplete;
            audiobook.TotalChapters = audiobook.Chapters.Count;
            audiobook.Duration = audiobook.Chapters.Sum(c => c.Duration);
        }
    }
}

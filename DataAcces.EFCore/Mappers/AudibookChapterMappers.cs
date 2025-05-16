using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.EFCore.Utils;
using Domain.DTOs.AudiobookChapterDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class AudibookChapterMappers
    {
        public static AudiobookChapterDto ToAudiobookChapter(this AudiobookChapter audiobookChapter)
        {
            return new AudiobookChapterDto
            {
                AudiobookChapterId = audiobookChapter.AudiobookChapterId,
                AudiobookId = audiobookChapter.AudiobookId,
                ChapterNumber = audiobookChapter.ChapterNumber,
                ChapterTitle = audiobookChapter.ChapterTitle,
                Duration = AppUtils.CalculateDurationToString(audiobookChapter.Duration),
                FileUrl = audiobookChapter.FileUrl,
                FileSize = audiobookChapter.FileSize,
            };
        }

        public static AudiobookChapter ToAudiobookChapterFromCreateDto(this AudiobookChapterCreateDto audioChapterCreateDto)
        {
            return new AudiobookChapter
            {
                AudiobookId = audioChapterCreateDto.AudiobookId,
                ChapterNumber = audioChapterCreateDto.ChapterNumber,
                ChapterTitle = audioChapterCreateDto.ChapterTitle,
                Duration = audioChapterCreateDto.Duration,
                FileUrl = audioChapterCreateDto.FileUrl,
                FileSize = audioChapterCreateDto.FileSize,
            };
        }

        public static void ToAudiobookChapterFromUpdateDto(this AudiobookChapter audiobookChapter, AudiobookChapterUpdateDto audiobookChapterUpdateDto)
        {
            audiobookChapter.AudiobookId = audiobookChapterUpdateDto.AudiobookId;
            audiobookChapter.ChapterNumber = audiobookChapterUpdateDto.ChapterNumber;
            audiobookChapter.ChapterTitle = audiobookChapterUpdateDto.ChapterTitle;
            audiobookChapter.Duration = audiobookChapterUpdateDto.Duration;
            audiobookChapter.FileUrl = audiobookChapterUpdateDto.FileUrl;
            audiobookChapter.FileSize = audiobookChapterUpdateDto.FileSize;
        }

        
    }
}

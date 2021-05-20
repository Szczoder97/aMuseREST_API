using AutoMapper;
using Dtos.Lesson;
using Models;

namespace aMuseAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
           CreateMap<Lesson, GetLessonDto>(); 
           CreateMap<AddLessonDto, Lesson>();
           CreateMap<AddLessonDto, GetLessonDto>();
        }
    }
}
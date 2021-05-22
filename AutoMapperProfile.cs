using AutoMapper;
using Dtos.Classroom;
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
           CreateMap<Classroom, GetClassroomDto>();
           CreateMap<AddClassroomDto, Classroom>();
           CreateMap<AddClassroomDto, GetClassroomDto>();
        }
    }
}
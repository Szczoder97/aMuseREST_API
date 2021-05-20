using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dtos.Lesson;
using Models;

namespace aMuseAPI.Services.LessonServies
{
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        public LessonService(IMapper mapper)
        {
            _mapper = mapper;

        }
        private static List<Lesson> lessons = new List<Lesson>{
            new Lesson(),
            new Lesson{id = 0, title = "pierwszy", text = "dsfjh", ytLink = "vfj"}
        };

        public async Task<ServiceResponse<GetLessonDto>> AddLesson(AddLessonDto l)
        {
            var serviceResponse = new ServiceResponse<GetLessonDto>();
            Lesson lesson = _mapper.Map<Lesson>(l);
            lesson.id = lessons.Max(c => c.id) + 1;
            lessons.Add(lesson);
            serviceResponse.data = _mapper.Map<GetLessonDto>(lesson);
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLessonDto>>> GetAllLessons()
        {
            var serviceResponse = new ServiceResponse<List<GetLessonDto>>();
            serviceResponse.data = lessons.Select(c => _mapper.Map<GetLessonDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLessonDto>> GetLessonById(int id)
        {
            var serviceResponse = new ServiceResponse<GetLessonDto>();
            serviceResponse.data = _mapper.Map<GetLessonDto>(lessons.FirstOrDefault(c => c.id == id));
            return serviceResponse;

        }

        public async Task<ServiceResponse<GetLessonDto>> UpdateLesson(UpdateLessonDto l)
        {
            var serviceResponse = new ServiceResponse<GetLessonDto>();
            try{
                Lesson lesson = lessons.FirstOrDefault(c => c.id == l.id);
                lesson.title = l.title;
                lesson.text = l.text;
                lesson.ytLink = l.ytLink;
                serviceResponse.data = _mapper.Map<GetLessonDto>(lesson);
            }catch(Exception e){
                serviceResponse.success = false;
                serviceResponse.messsage = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLessonDto>>> RemoveLesson(int id)
        {
             var serviceResponse = new ServiceResponse<List<GetLessonDto>>();
            try{
                Lesson lesson = lessons.First(c => c.id == id);
                lessons.Remove(lesson);
                serviceResponse.data = lessons.Select(c => _mapper.Map<GetLessonDto>(c)).ToList();
            }catch(Exception e){
                serviceResponse.success = false;
                serviceResponse.messsage = e.Message;
            }
            return serviceResponse;
        }
    }
}
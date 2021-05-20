using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos.Lesson;
using Microsoft.EntityFrameworkCore;
using Models;

namespace aMuseAPI.Services.LessonServies
{
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        public LessonService(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;

        }
        private static List<Lesson> lessons = new List<Lesson>{
            new Lesson(),
            new Lesson{id = 0, title = "pierwszy", text = "dsfjh", ytLink = "vfj"}
        };

        public async Task<ServiceResponse<GetLessonDto>> AddLesson(AddLessonDto l)
        {
            var serviceResponse = new ServiceResponse<GetLessonDto>();
            Lesson lesson = _mapper.Map<Lesson>(l);
            _dataContext.lessons.Add(lesson);
            await _dataContext.SaveChangesAsync();
            serviceResponse.data = 
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLessonDto>>> GetAllLessons()
        {
            var serviceResponse = new ServiceResponse<List<GetLessonDto>>();
            var dbLessons = await _dataContext.lessons.ToListAsync();
            serviceResponse.data = dbLessons.Select(c => _mapper.Map<GetLessonDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLessonDto>> GetLessonById(int id)
        {
            var serviceResponse = new ServiceResponse<GetLessonDto>();
            var dbLesson = await _dataContext.lessons.FirstOrDefaultAsync(c => c.id == id);
            serviceResponse.data = _mapper.Map<GetLessonDto>(dbLesson);
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
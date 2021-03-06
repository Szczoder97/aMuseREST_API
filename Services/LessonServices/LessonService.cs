using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos.Lesson;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;

namespace aMuseAPI.Services.LessonServies
{
    public class LessonService : ILessonService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _contextAccessor;
        public LessonService(IMapper mapper, DataContext dataContext, IHttpContextAccessor contextAccessor)
        {
            _mapper = mapper;
            _dataContext = dataContext;
            _contextAccessor = contextAccessor;

        }
        private int GetUserId() =>int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
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
            try
            {
                Lesson lesson = await _dataContext.lessons.FirstOrDefaultAsync(c => c.id == l.id && c.user.id == GetUserId());
                if(lesson != null)
                {
                    lesson.title = l.title;
                    lesson.text = l.text;
                    lesson.ytLink = l.ytLink;
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.data = _mapper.Map<GetLessonDto>(lesson);
                }
                else
                {
                    serviceResponse.success = false;
                    serviceResponse.messsage = "Not found!";
                }
            }
            catch (Exception e)
            {
                serviceResponse.success = false;
                serviceResponse.messsage = e.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetLessonDto>>> RemoveLesson(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetLessonDto>>();
            try
            {
                Lesson lesson = await _dataContext.lessons.FirstOrDefaultAsync(c => c.id == id && c.user.id == GetUserId());
                if(lesson != null)
                {
                    _dataContext.lessons.Remove(lesson);
                    await _dataContext.SaveChangesAsync();
                    serviceResponse.data = _dataContext.lessons
                    .Select(c => _mapper.Map<GetLessonDto>(c)).ToList();
                }
                else
                {
                    serviceResponse.success = false;
                    serviceResponse.messsage = "Not found!";
                }
                
            }
            catch (Exception e)
            {
                serviceResponse.success = false;
                serviceResponse.messsage = e.Message;
            }
            return serviceResponse;
        }
    }
}
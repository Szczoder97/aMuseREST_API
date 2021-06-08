using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos.Classroom;
using Dtos.Lesson;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services.ClassroomServices
{
    public class ClassroomService : IClassroomService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;
        public ClassroomService(DataContext context, IMapper mapper, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
        }
        public async Task<ServiceResponse<List<GetClassroomDto>>> AddClassroom(AddClassroomDto c)
        {
            Classroom classroom = _mapper.Map<Classroom>(c);
            classroom.user = await _context.users.FirstOrDefaultAsync(u => u.id == GetUserId());
            _context.classrooms.Add(classroom);
            await _context.SaveChangesAsync();
            return await GetMyClassrooms();
        }

        public async Task<ServiceResponse<GetClassroomDto>> AddLessonToClassroom(int classroomId, AddLessonDto l)
        {
            var response = new ServiceResponse<GetClassroomDto>();
            var dbClassroom = await _context.classrooms.FirstOrDefaultAsync(c => c.id == classroomId && c.user.id == GetUserId());
            if(dbClassroom != null)
            {
                 Lesson lesson = _mapper.Map<Lesson>(l);
                lesson.classroom = dbClassroom;
                lesson.user = await _context.users.FirstOrDefaultAsync(u => u.id == GetUserId());
                _context.lessons.Add(lesson);
                await _context.SaveChangesAsync();
                response.data = _mapper.Map<GetClassroomDto>(dbClassroom);
            }
            else
            {
                response.success = false;
                response.messsage = "Not found!";
            }
            return response;

        }

        public async Task<ServiceResponse<List<GetClassroomDto>>> GetAllClassrooms()
        {
            var response = new ServiceResponse<List<GetClassroomDto>>();
            var dbClassrooms = await _context.classrooms.ToListAsync();
            response.data = dbClassrooms.Select(c => _mapper.Map<GetClassroomDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetClassroomDto>> GetClassroomById(int id)
        {
            var response = new ServiceResponse<GetClassroomDto>();
            var dbClassroom = await _context.classrooms.FirstOrDefaultAsync(c => c.id == id);
            response.data = _mapper.Map<GetClassroomDto>(dbClassroom);
            return response;
        }

        public async Task<ServiceResponse<List<GetLessonDto>>> GetLessonsFromClassroom(int classroomId)
        {
            var response = new ServiceResponse<List<GetLessonDto>>();
            var dbClassroom = await _context.classrooms.FirstOrDefaultAsync(c => c.id == classroomId);
            var dbLessons = await _context.lessons.Where(c => c.classroom == dbClassroom).ToListAsync();
            response.data = dbLessons.Select(c => _mapper.Map<GetLessonDto>(c)).ToList();
            return response;

        }

        public async Task<ServiceResponse<List<GetClassroomDto>>> GetMyClassrooms()
        {
            var response = new ServiceResponse<List<GetClassroomDto>>();
            var dbClassrooms = await _context.classrooms.Where(c => c.user.id == GetUserId()).ToListAsync();
            response.data = dbClassrooms.Select(c => _mapper.Map<GetClassroomDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<List<GetClassroomDto>>> RemoveClassroom(int id)
        {
            var response = new ServiceResponse<List<GetClassroomDto>>();
            try
            {
                Classroom classroom = await _context.classrooms.FirstOrDefaultAsync(c => c.id == id && c.user.id == GetUserId());
                if(classroom != null)
                {
                _context.classrooms.Remove(classroom);
                await _context.SaveChangesAsync();
                response.data = _context.classrooms
                .Where(c => c.user.id == GetUserId())
                .Select(c => _mapper.Map<GetClassroomDto>(c)).ToList();
                }
                else
                {
                    response.success = false;
                    response.messsage = "Classroom not found!";
                }
            }
            catch (Exception e)
            {
                response.success = false;
                response.messsage = e.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetClassroomDto>> UpdateClassroom(UpdateClassroomDto x)
        {
            var response = new ServiceResponse<GetClassroomDto>();
            try
            {
                Classroom classroom = await _context.classrooms
                .Include(c => c.user)
                .FirstOrDefaultAsync(c => c.id == x.id && c.user.id == GetUserId());
                if(classroom != null)
                {
                    classroom.title = x.title;
                    classroom.description = x.description;
                    await _context.SaveChangesAsync();
                    response.data = _mapper.Map<GetClassroomDto>(classroom);
                }
                else
                {
                    response.success = false;
                    response.messsage = "Classroom not Found";
                }
            }
            catch (Exception e)
            {
                response.success = false;
                response.messsage = e.Message;
            }
            return response;
        }
        private int GetUserId() => int.Parse(_contextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        
    }
}
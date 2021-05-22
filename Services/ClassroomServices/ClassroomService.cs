using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos.Classroom;
using Dtos.Lesson;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Services.ClassroomServices
{
    public class ClassroomService : IClassroomService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ClassroomService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetClassroomDto>>> AddClassroom(AddClassroomDto c)
        {
            var response = new ServiceResponse<List<GetClassroomDto>>();
            Classroom classroom = _mapper.Map<Classroom>(c);
            _context.classrooms.Add(classroom);
            await _context.SaveChangesAsync();
            response.data = await _context.classrooms.Select(c => _mapper.Map<GetClassroomDto>(c)).ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<GetClassroomDto>> AddLessonToClassroom(int classroomId, AddLessonDto l)
        {
            var response = new ServiceResponse<GetClassroomDto>();
            var dbClassroom = await _context.classrooms.FirstOrDefaultAsync(c => c.id == classroomId);
            Lesson lesson = _mapper.Map<Lesson>(l);
            lesson.classroom = dbClassroom;
            _context.lessons.Add(lesson);
            await _context.SaveChangesAsync();
            response.data = _mapper.Map<GetClassroomDto>(dbClassroom);
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

        public async Task<ServiceResponse<List<GetClassroomDto>>> RemoveClassroom(int id)
        {
            var response = new ServiceResponse<List<GetClassroomDto>>();
            try
            {
                Classroom classroom = await _context.classrooms.FirstAsync(c => c.id == id);
                _context.classrooms.Remove(classroom);
                await _context.SaveChangesAsync();
                response.data = _context.classrooms.Select(c => _mapper.Map<GetClassroomDto>(c)).ToList();
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
                Classroom classroom = await _context.classrooms.FirstOrDefaultAsync(c => c.id == x.id);
                classroom.title = x.title;
                classroom.description = x.description;
                await _context.SaveChangesAsync();
                response.data = _mapper.Map<GetClassroomDto>(classroom);
            }
            catch (Exception e)
            {
                response.success = false;
                response.messsage = e.Message;
            }
            return response;
        }
    }
}
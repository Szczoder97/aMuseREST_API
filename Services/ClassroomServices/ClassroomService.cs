using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data;
using Dtos.Classroom;
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
            var dbClassrooms = await _context.classrooms.FirstOrDefaultAsync(c => c.id == id);
            response.data = _mapper.Map<GetClassroomDto>(dbClassrooms);
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
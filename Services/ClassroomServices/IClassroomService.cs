using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos.Classroom;
using Dtos.Lesson;
using Models;

namespace Services.ClassroomServices
{
    public interface IClassroomService
    {
        public Task<ServiceResponse<List<GetClassroomDto>>> AddClassroom(AddClassroomDto c);
        public Task<ServiceResponse<List<GetClassroomDto>>> GetAllClassrooms();
        public Task<ServiceResponse<GetClassroomDto>> GetClassroomById(int id);
        public Task<ServiceResponse<GetClassroomDto>> UpdateClassroom(UpdateClassroomDto x);
        public Task<ServiceResponse<List<GetClassroomDto>>> RemoveClassroom(int id);
        public Task<ServiceResponse<GetClassroomDto>> AddLessonToClassroom(int classroomId, AddLessonDto l);
        public Task<ServiceResponse<List<GetLessonDto>>> GetLessonsFromClassroom(int classroomId);
    }
}
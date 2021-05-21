using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos.Lesson;
using Models;

namespace aMuseAPI.Services.LessonServies
{
    public interface ILessonService{
        public Task<ServiceResponse<List<GetLessonDto>>> AddLesson(AddLessonDto l);
        public Task<ServiceResponse<List<GetLessonDto>>> GetAllLessons(int userId);
        public Task<ServiceResponse<GetLessonDto>> GetLessonById(int id);
        public Task<ServiceResponse<GetLessonDto>> UpdateLesson(UpdateLessonDto l);
        public Task<ServiceResponse<List<GetLessonDto>>> RemoveLesson(int id);
    }
}
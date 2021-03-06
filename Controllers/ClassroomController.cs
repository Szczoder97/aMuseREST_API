using System.Collections.Generic;
using System.Threading.Tasks;
using Dtos.Classroom;
using Dtos.Lesson;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.ClassroomServices;

namespace Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;
        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetClassroomDto>>> GetClassroomById(int id)
        {
            return Ok(await _classroomService.GetClassroomById(id));
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetClassroomDto>>>> GetAllClassrooms()
        {
            
            return Ok(await _classroomService.GetAllClassrooms());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetClassroomDto>>>> AddLesson(AddClassroomDto c)
        {
            return Ok(await _classroomService.AddClassroom(c));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetClassroomDto>>> UpdateLesson(UpdateClassroomDto x)
        {
            var response = await _classroomService.UpdateClassroom(x);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetClassroomDto>>>> RemoveClassroom(int id)
        {
            var response = await _classroomService.RemoveClassroom(id);
            if (response == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<ServiceResponse<GetClassroomDto>>> AddLessonToClass(int id, AddLessonDto l)
        {
            return Ok(await _classroomService.AddLessonToClassroom(id, l));
        }
        [HttpGet("{id}/lessons")]
        public async Task<ActionResult<ServiceResponse<List<GetLessonDto>>>> GetLessonsFromClassroom(int id)
        {
            return Ok(await _classroomService.GetLessonsFromClassroom(id));
        }
        [HttpGet("my")]
        public async Task<ActionResult<List<GetClassroomDto>>> GetMyClassrooms()
        {
            return Ok(await _classroomService.GetMyClassrooms());
        }
    }
}


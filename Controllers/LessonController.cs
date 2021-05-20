using System.Collections.Generic;
using System.Threading.Tasks;
using aMuseAPI.Services.LessonServies;
using Dtos.Lesson;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace aMuseAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService){
            _lessonService = lessonService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetLessonDto>>> GetLessonById(int id){
            return Ok(await _lessonService.GetLessonById(id));
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetLessonDto>>>> GetAllLessons(){
            return Ok(await _lessonService.GetAllLessons());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetLessonDto>>> AddLesson(AddLessonDto l){
            return Ok(await _lessonService.AddLesson(l));
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetLessonDto>>> UpdateLesson(UpdateLessonDto l){
            var response = await _lessonService.UpdateLesson(l);
            if(response == null){
                return NotFound(response);
            }
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetLessonDto>>>> RemoveLesson(int id){
            var response = await _lessonService.RemoveLesson(id);
            if(response == null){
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}

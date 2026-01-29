using Microsoft.AspNetCore.Mvc;
using Tasks.Application.DTO.Business;
using Tasks.Application.DTO.Response;
using Tasks.WebApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tasks.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        // GET: api/<TasksController>
        private readonly ITasksService _service;

        public TasksController(ITasksService service) {
            _service = service;    
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseDto response = await _service.GetAllTasks();
            return response.IsValid ? Ok(response) : NotFound(response);
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            ResponseDto response = await _service.GetById(id);
            return response.IsValid ? Ok(response) : NotFound(response);
        }

        // POST api/<TasksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskDto value)
        {
            ResponseDto response = await _service.CreateNew(value);
            return response.IsValid ? Ok(response) : BadRequest(response);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}/status")]
        public async Task<IActionResult> Put(int id)
        {
            ResponseDto response = await _service.ChangeStatus(id);
            return response.IsValid ? Ok(response) : BadRequest(response);
        }        
    }
}

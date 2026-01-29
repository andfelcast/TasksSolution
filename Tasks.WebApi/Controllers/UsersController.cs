using Microsoft.AspNetCore.Mvc;
using Tasks.Application.DTO.Business;
using Tasks.Application.DTO.Response;
using Tasks.WebApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tasks.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<TasksController>
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseDto response = await _service.GetAllUsers();
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
        public async Task<IActionResult> Post([FromBody] UserDto value)
        {
            ResponseDto response = await _service.CreateNew(value);
            return response.IsValid ? Ok(response) : BadRequest(response);
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDto value)
        {
            ResponseDto response = await _service.Update(value);
            return response.IsValid ? Ok(response) : BadRequest(response);
        }
    }
}

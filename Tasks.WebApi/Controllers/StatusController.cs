using Microsoft.AspNetCore.Mvc;
using Tasks.Application.DTO.Response;
using Tasks.WebApi.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tasks.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IGeneralService _service;

        public StatusController(IGeneralService service)
        {
            _service = service;
        }
        // GET: api/<StatusController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ResponseDto response = await _service.GetStatusList();
            return response.IsValid ? Ok(response) : NotFound(response);
        }        
    }
}

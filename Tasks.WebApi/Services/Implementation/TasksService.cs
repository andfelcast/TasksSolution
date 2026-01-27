using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.DTO.Business;
using Tasks.Application.DTO.Response;
using Tasks.Domain.Repositories.Interfaces;
using Tasks.WebApi.Services.Interfaces;

namespace Tasks.Application.Services.Implementation
{
    public class TasksService: ITasksService
    {
        private readonly ITasksRepository _repository;

        public TasksService(ITasksRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDto> GetAllTasks() {
            ResponseDto objDto = new ResponseDto();
            List<TaskDto> lstTasks = new List<TaskDto>();
            foreach (var item in await _repository.GetAll()) {
                lstTasks.Add(Converter.ConvertToDto(item));
            }
            objDto.IsValid = lstTasks.Any();
            objDto.ResultData = lstTasks;
            return objDto;
        }
    }
}

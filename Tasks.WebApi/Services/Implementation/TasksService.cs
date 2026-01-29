using Microsoft.EntityFrameworkCore;
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

        public async Task<ResponseDto> GetById(int id)
        {
            ResponseDto objDto = new ResponseDto();
            TaskDto task = Converter.ConvertToDto(await _repository.GetById(id));            
            objDto.IsValid = task != null;
            objDto.ResultData = task;
            return objDto;            
        }

        public async Task<ResponseDto> CreateNew(TaskDto value)
        {
            ResponseDto objDto = new ResponseDto();
            bool valid = await _repository.CreateNew(Converter.ConvertToEntity(value));            
            objDto.IsValid = valid;            
            return objDto;
        }

        public async Task<ResponseDto> Update(TaskDto value)
        {
            ResponseDto objDto = new ResponseDto();
            bool valid = await _repository.Update(Converter.ConvertToEntity(value));
            objDto.IsValid = valid;
            return objDto;
        }

        public async Task<ResponseDto> ChangeStatus(int id)
        {
            ResponseDto objDto = new ResponseDto();
            Domain.Entities.Task task = await _repository.GetById(id);
            int newStatusId = 3;
            if (task.StatusId < 3)
                newStatusId = task.StatusId + 1;
            bool valid = await _repository.ChangeStatus(id, newStatusId);
            objDto.IsValid = valid;
            return objDto;            
        }
    }
}

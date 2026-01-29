using Tasks.Application.DTO.Business;
using Tasks.Application.DTO.Response;

namespace Tasks.WebApi.Services.Interfaces
{
    public interface ITasksService
    {
        Task<ResponseDto> GetAllTasks();
        Task<ResponseDto> GetById(int id);
        Task<ResponseDto> CreateNew(TaskDto value);
        Task<ResponseDto> Update(TaskDto value);
        Task<ResponseDto> ChangeStatus(int id);
    }
}

using Tasks.Application.DTO.Response;

namespace Tasks.WebApi.Services.Interfaces
{
    public interface ITasksService
    {
        Task<ResponseDto> GetAllTasks();
    }
}

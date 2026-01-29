using Tasks.Application.DTO.Business;
using Tasks.Application.DTO.Response;

namespace Tasks.WebApi.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ResponseDto> GetAllUsers();
        Task<ResponseDto> GetById(int id);
        Task<ResponseDto> CreateNew(UserDto value);
        Task<ResponseDto> Update(UserDto value);
    }
}

using System.Threading.Tasks;
using Tasks.Application.DTO.Response;

namespace Tasks.WebApi.Services.Interfaces
{
    public interface IGeneralService
    {
        Task<ResponseDto> GetStatusList();
    }
}

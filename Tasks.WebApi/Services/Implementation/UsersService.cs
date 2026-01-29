using Tasks.Application.DTO.Business;
using Tasks.Application.DTO.Response;
using Tasks.Domain.Repositories.Interfaces;
using Tasks.WebApi.Services.Interfaces;

namespace Tasks.Application.Services.Implementation
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _repository;

        public UsersService(IUsersRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseDto> GetAllUsers()
        {
            ResponseDto objDto = new ResponseDto();
            List<UserDto> lstUsers = new List<UserDto>();
            foreach (var item in await _repository.GetAllUsers())
            {
                lstUsers.Add(Converter.ConvertToDto(item));
            }
            objDto.IsValid = lstUsers.Any();
            objDto.ResultData = lstUsers;
            return objDto;
        }

        public async Task<ResponseDto> GetById(int id)
        {
            ResponseDto objDto = new ResponseDto();
            UserDto user = Converter.ConvertToDto(await _repository.GetById(id));
            objDto.IsValid = user != null;
            objDto.ResultData = user;
            return objDto;
        }

        public async Task<ResponseDto> CreateNew(UserDto value)
        {
            ResponseDto objDto = new ResponseDto();
            bool valid = await _repository.CreateNew(Converter.ConvertToEntity(value));
            objDto.IsValid = valid;
            return objDto;
        }

        public async Task<ResponseDto> Update(UserDto value)
        {
            ResponseDto objDto = new ResponseDto();
            bool valid = await _repository.Update(Converter.ConvertToEntity(value));
            objDto.IsValid = valid;
            return objDto;
        }
    }
}

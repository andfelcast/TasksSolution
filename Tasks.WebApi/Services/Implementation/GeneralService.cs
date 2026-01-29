using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.DTO.General;
using Tasks.Application.DTO.Response;
using Tasks.Domain.Repositories.Interfaces;
using Tasks.WebApi.Services.Interfaces;

namespace Tasks.Application.Services.Implementation
{
    public class GeneralService : IGeneralService
    {
        private readonly IGeneralRepository _repository;

        public GeneralService(IGeneralRepository repository) {
            _repository = repository;
        }
        public async Task<ResponseDto> GetStatusList() {
            ResponseDto objDto = new ResponseDto();
            List<StatusDto> lstDto = new List<StatusDto>();
            foreach (var item in await _repository.GetStatuses()) {
                lstDto.Add(Converter.ConvertToDto(item));
            }
            objDto.IsValid = lstDto.Any();
            objDto.ResultData = lstDto;
            return objDto;
        }
    }
}

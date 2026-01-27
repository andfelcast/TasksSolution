using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.DTO.Business;
using Tasks.Application.DTO.General;
using Tasks.Domain.Entities;

namespace Tasks.Application
{
    public static class Converter
    {
        public static TaskDto ConvertToDto(Domain.Entities.Task entity) {
            return new TaskDto
            {
                AdditionalInfo = entity.AdditionalInfo,
                Duration = entity.Duration,
                EndDate = entity.EndDate,
                Id = entity.Id,
                Name = entity.Name,
                StartDate = entity.StartDate,
                StatusId = entity.StatusId,
                StatusName = entity.Status.Name,
            };
        }

        public static StatusDto ConvertToDto(Status entity)
        {
            return new StatusDto
            {                
                Id = entity.Id,
                Name = entity.Name,                
            };
        }
    }
}

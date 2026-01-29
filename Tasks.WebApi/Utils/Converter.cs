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
                Id = entity.Id,
                Name = entity.Name,                
                StatusId = entity.StatusId,
                StatusName = entity.Status.Name,
                UserId = entity.UserId,
                UserName = entity.User.FirstName + " " + entity.User.LastName,
            };
        }

        public static UserDto ConvertToDto(User entity)
        {
            return new UserDto
            {
                DocumentNumber = entity.DocumentNumber,
                Email = entity.Email,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                PhoneNumber = entity.PhoneNumber,
                Id = entity.Id                
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

        public static Domain.Entities.Task ConvertToEntity(TaskDto value)
        {
            return new Domain.Entities.Task
            {
                AdditionalInfo = value.AdditionalInfo,
                Duration = value.Duration,
                CreationDate = value.CreationDate,
                Id = value.Id,
                Name = value.Name,
                StatusId = value.StatusId,
                UserId = value.UserId,
            };
        }

        public static User ConvertToEntity(UserDto value)
        {
            return new User
            {
                DocumentNumber = value.DocumentNumber,
                Email = value.Email,
                FirstName = value.FirstName,
                LastName = value.LastName,
                PhoneNumber = value.PhoneNumber,
                Id = value.Id
            };
        }
    }
}

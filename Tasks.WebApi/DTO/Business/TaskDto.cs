    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Application.DTO.Business
{
    public class TaskDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }       
        public DateTime CreationDate { get; set; }
        public int Duration { get; set; }
        public int StatusId { get; set; }
        public string? StatusName { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? AdditionalInfo { get; set; }

    }
}

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
        public string Name { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Duration { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string AdditionalInfo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Domain.Repositories.Interfaces
{
    public interface ITasksRepository
    {
        Task<List<Entities.Task>> GetAll();
        Task<Entities.Task> GetById(int id);
        Task<bool> CreateNew(Entities.Task newTask);
        Task<bool> Update(Entities.Task updTask);
        Task<bool> ChangeStatus(int id, int statusId);
    }
}

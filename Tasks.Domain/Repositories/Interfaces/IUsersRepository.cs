using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Domain.Entities;

namespace Tasks.Domain.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetById(int id);
        Task<bool> CreateNew(User newUser);
        Task<bool> Update(User updUser);
    }
}

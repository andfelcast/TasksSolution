using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tasks.Domain.Repositories.Interfaces;
using Tasks.Infrastructure.Persistence;

namespace Tasks.Infrastructure.Repositories.Implementation
{
    public class TasksRepository: ITasksRepository
    {
        private readonly TaskingDbContext _context;

        public TasksRepository(TaskingDbContext context) { 
            _context = context;
        }
        public async Task<List<Domain.Entities.Task>> GetAll() {
            return await _context.Tasks.Include(x => x.User).Include(x => x.Status).ToListAsync();
        }
    }
}

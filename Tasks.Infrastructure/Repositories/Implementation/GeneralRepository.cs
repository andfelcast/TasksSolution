using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Domain.Entities;
using Tasks.Domain.Repositories.Interfaces;
using Tasks.Infrastructure.Persistence;

namespace Tasks.Infrastructure.Repositories.Implementation
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly TaskingDbContext _context;

        public GeneralRepository(TaskingDbContext context)
        {
            _context = context;
        }
        public async Task<List<Status>> GetStatuses() {
            return await _context.Statuses.ToListAsync();
        }
    }
}

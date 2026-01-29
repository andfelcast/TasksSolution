using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Domain.Entities.Task>> GetAll()
        {
            return await _context.Tasks.Include(x => x.User).Include(x => x.Status).ToListAsync();
        }
        public async Task<Domain.Entities.Task> GetById(int id)
        {
            return await _context.Tasks.Include(x => x.User).Include(x => x.Status).FirstAsync(w => w.Id == id);
        }
        public async Task<bool> CreateNew(Domain.Entities.Task newTask)
        {
            try
            {
                newTask.StatusId = 1;
                newTask.CreationDate = DateTime.Now;
                await _context.Tasks.AddAsync(newTask);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
        public async Task<bool> Update(Domain.Entities.Task updTask)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == updTask.Id);
                if (task != null)
                {
                    task.Name = updTask.Name;
                    task.UpdateDate = DateTime.Now;                    
                    task.Duration = updTask.Duration;
                    _context.Entry(task).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception) {
                return false;
            }
        }
        public async Task<bool> ChangeStatus(int id, int statusId)
        {
            try
            {
                var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
                if (task != null)
                {
                    task.StatusId = statusId;
                    task.UpdateDate = DateTime.Now;                    
                    _context.Entry(task).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

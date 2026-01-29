using Microsoft.EntityFrameworkCore;
using Tasks.Domain.Entities;
using Tasks.Domain.Repositories.Interfaces;
using Tasks.Infrastructure.Persistence;

namespace Tasks.Infrastructure.Repositories.Implementation
{
    public class UsersRepository: IUsersRepository
    {
        private readonly TaskingDbContext _context;

        public UsersRepository(TaskingDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstAsync(w => w.Id == id);
        }
        public async Task<bool> CreateNew(User newUser)
        {
            try
            {
                newUser.CreationDate = DateTime.Now;                
                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> Update(User updUser)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == updUser.Id);
                if (user != null)
                {
                    user.FirstName = updUser.FirstName;
                    user.PhoneNumber = updUser.PhoneNumber;
                    user.DocumentNumber = updUser.DocumentNumber;
                    user.LastName = updUser.LastName;
                    user.Email = updUser.Email;
                    _context.Entry(user).State = EntityState.Modified;
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

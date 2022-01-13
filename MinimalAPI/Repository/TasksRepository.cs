using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;

namespace MinimalAPI.Repository
{
    public class TasksRepository : ITasksRespository
    {
        private readonly ApplicationDbContext _context;

        public TasksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tasks> GetById(int id)
        {
            return await _context.Tasks.FirstAsync(t=>t.Id==id);
        }

        public async Task<IEnumerable<Tasks>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<IEnumerable<Tasks>> GetTasksCompleted()
        {
            return await _context.Tasks.Where(t => t.IsCompleted == true).ToListAsync();
        }

        public async Task<IEnumerable<Tasks>> GetTasksIncompleted()
        {
            return await _context.Tasks.Where(t => t.IsCompleted == false).ToListAsync();
        }


        public async Task<bool> SaveTask(Tasks tasks)
        {
            try
            {
                _context.Entry(tasks).State = tasks.Id > 0 ? EntityState.Modified : EntityState.Added;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

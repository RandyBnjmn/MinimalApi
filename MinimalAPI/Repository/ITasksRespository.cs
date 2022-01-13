using MinimalAPI.Models;

namespace MinimalAPI.Repository
{
    public interface ITasksRespository
    {
        Task<IEnumerable<Tasks>> GetTasks();
        Task<IEnumerable<Tasks>> GetTasksCompleted();
        Task<IEnumerable<Tasks>> GetTasksIncompleted();
        Task<bool> SaveTask(Tasks tasks);
        Task<Tasks> GetById(int id);

    }
}

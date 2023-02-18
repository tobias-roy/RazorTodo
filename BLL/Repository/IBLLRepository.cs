using RazorProject.BLL.Models;
namespace RazorProject.BLL.Repository
{
  public interface IBLLRepository
    {
        public List<TodoTask> GetUnfinishedTasks();
        public List<TodoTask> GetFinishedTasks();
        // bool InsertTask(string description, Priority priority, bool completed);
        bool InsertTask(TodoTask task);
    }
}

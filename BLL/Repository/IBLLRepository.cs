using RazorProject.BLL.Models;
namespace RazorProject.BLL.Repository
{
  public interface IBLLRepository
    {
        public List<TodoTask> GetUnfinishedTasks();
        public List<TodoTask> GetFinishedTasks();
        public bool MarkTaskAsFinished(Guid id);
        public bool MarkTaskAsUnFinished(Guid id);
        bool InsertTask(TodoTask task);
    }
}

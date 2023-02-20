using RazorProject.Pages.Models;
namespace RazorProject.Pages.Repository
{
  public interface IUIRepository
    {
        public List<TodoTask> GetUnfinishedTasks();
        public List<TodoTask> GetFinishedTasks();
        public TodoTask GetTaskById(Guid id);
        public bool MarkTaskAsFinished(Guid id);
        public bool MarkTaskAsUnFinished(Guid id);
        public bool DeleteTask(Guid id);
        public bool InsertTask(InputTask task);
    }
}

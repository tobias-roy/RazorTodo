using RazorProject.Pages.Models;
using RazorProject.Definitions;
namespace RazorProject.Pages.Repository
{
  public interface IUIRepository
    {
        public List<TodoTask> GetUnfinishedTasks();
        public List<TodoTask> GetFinishedTasks();
        public bool MarkTaskAsFinished(Guid id);
        public bool MarkTaskAsUnFinished(Guid id);
        bool InsertTask(string description, Priority priority, bool completed);
    }
}

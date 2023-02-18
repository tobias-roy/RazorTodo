using RazorProject.Pages.Models;
using RazorProject.Definitions;
namespace RazorProject.Pages.Repository
{
  public interface IUIRepository
    {
        public List<TodoTask> GetTodoTasks();
        bool InsertTask(string description, Priority priority, bool completed);
    }
}

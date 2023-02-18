using RazorProject.BLL.Models;
namespace RazorProject.BLL.Controllers
{
  public interface ITaskListController
    { 
        public List<TodoTask> GetUnfinishedTasks();
        public List<TodoTask> GetFinishedTasks();
        public bool InsertTask(RazorProject.Pages.Models.TodoTask uiTask);
    }
}

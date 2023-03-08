using RazorProject.BLL.Models;
namespace RazorProject.BLL.Controllers
{
  public interface ITaskListController
    { 
        public List<TodoTask> GetUnfinishedTasks(string Username);
        public List<TodoTask> GetFinishedTasks(string Username);
        public bool InsertTask(RazorProject.Pages.Models.TodoTask uiTask);
    }
}

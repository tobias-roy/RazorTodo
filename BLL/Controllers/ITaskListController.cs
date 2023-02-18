using RazorProject.BLL.Models;
namespace RazorProject.BLL.Controllers
{
  public interface ITaskListController
    { 
        public List<TodoTask> GetListOfTasks();
        public bool InsertTask(RazorProject.Pages.Models.TodoTask uiTask);
    }
}

using RazorProject.Pages.Models;
using RazorProject.BLL.Controllers;
using RazorProject.Definitions;

namespace RazorProject.Pages.Repository
{
  public class UIRepository : IUIRepository
    {
        private readonly ITaskListController _taskListController;
        public UIRepository(ITaskListController taskListController){
            _taskListController = taskListController;
        }

    public List<TodoTask> GetUnfinishedTasks()
    {
        var bllList = _taskListController.GetUnfinishedTasks();
        return bllList.Select(o => new TodoTask(o)).ToList();
    }
    public List<TodoTask> GetFinishedTasks()
    {
        var bllList = _taskListController.GetFinishedTasks();
        return bllList.Select(o => new TodoTask(o)).ToList();
    }

    public bool InsertTask(string description, Priority priority, bool completed){
      TodoTask task = new(){
        Description = description,
        Priority = priority,
        Completed = completed
      };

      _taskListController.InsertTask(task);
      return true;
    }
  }
}

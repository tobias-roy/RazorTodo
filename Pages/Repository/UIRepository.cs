using RazorProject.Pages.Models;
using RazorProject.BLL.Controllers;

namespace RazorProject.Pages.Repository
{
  public class UIRepository : IUIRepository
    {
        private readonly ITaskListController _taskListController;
        private readonly ISingleTaskController _singleTaskController;
        public UIRepository(ITaskListController taskListController, ISingleTaskController singleTaskController){
            _taskListController = taskListController;
            _singleTaskController = singleTaskController;
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

    public bool InsertTask(InputTask task){
      TodoTask controllerTask = new(){
        Description = task.Description,
        Priority = task.Priority,
      };
      _taskListController.InsertTask(controllerTask);
      return true;
    }

     public bool MarkTaskAsFinished(Guid id)
    {
      _singleTaskController.MarkTaskAsFinished(id);
      return true;
    }

    public bool MarkTaskAsUnFinished(Guid id)
    {
      _singleTaskController.MarkTaskAsUnFinished(id);
      return true;
    }

    public bool DeleteTask(Guid id){
      _singleTaskController.DeleteTask(id);
      return true;
    }
  }
}

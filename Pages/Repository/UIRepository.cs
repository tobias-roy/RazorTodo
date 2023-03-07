using RazorProject.Pages.Models;
using RazorProject.BLL.Controllers;

namespace RazorProject.Pages.Repository
{
  public class UIRepository : IUIRepository
    {
        private readonly ITaskListController _taskListController;
        private readonly ISingleTaskController _singleTaskController;
        private readonly IUserController _userController;
        private readonly IConnectionController _connectionController;
        public UIRepository(ITaskListController taskListController, ISingleTaskController singleTaskController, IConnectionController connectionController, IUserController userController){
            _taskListController = taskListController;
            _singleTaskController = singleTaskController;
            _connectionController = connectionController;
            _userController = userController;
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
      TodoTask uiTask = new(){
        Description = task.Description,
        Priority = task.Priority,
      };
      _taskListController.InsertTask(uiTask);
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

    public TodoTask GetTaskById(Guid id)
    {
       return _singleTaskController.GetTaskById(id);
    }

    public bool UpdateTask(TodoTask task)
    {
      _singleTaskController.UpdateTask(task);
      return true;
    }

    public bool CheckConnection(){
      return _connectionController.CheckConnection();
    }

    public void RegisterNewUser(UserCredentials user)
    {
      _userController.CreateNewUser(user);
    }

    public bool Login(UserCredentials user)
    {
      return _userController.Login(user);
    }
  }
}

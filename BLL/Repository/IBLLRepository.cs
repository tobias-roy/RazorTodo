using RazorProject.BLL.Models;
namespace RazorProject.BLL.Repository
{
  public interface IBLLRepository
  {
    public List<TodoTask> GetUnfinishedTasks();
    public List<TodoTask> GetFinishedTasks();
    public TodoTask GetTaskById(Guid id);
    public bool MarkTaskAsFinished(Guid id);
    public bool MarkTaskAsUnFinished(Guid id);
    public bool DeleteTask(Guid id);
    public bool InsertTask(TodoTask task);
    public bool UpdateTask(TodoTask todoTask);
    public bool CheckConnection();
    public void CreateNewUser(UserCredentials bllUser);
    public bool Login(UserCredentials bllUser);
  }
}

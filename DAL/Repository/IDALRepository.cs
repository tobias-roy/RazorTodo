using RazorProject.DAL.Models;

namespace RazorProject.DAL.Repository
{
  public interface IDALRepository
  {
    public List<TodoTask> GetUnfinishedTasks(string Username);
    public List<TodoTask> GetFinishedTasks(string Username);
    public TodoTask GetTaskById(Guid id);
    public bool MarkTaskAsFinished(Guid id);
    public bool MarkTaskAsUnFinished(Guid id);
    public bool InsertTask(TodoTask task);
    public bool DeleteTask(Guid id);
    public bool UpdateTask(TodoTask todoTask);
    public bool CheckConnection();
    public bool CreateNewUser(BLL.Models.UserCredentials bllUser);
    public bool Login(BLL.Models.UserCredentials bllUser);
  }
}

using RazorProject.Pages.Models;
namespace RazorProject.Pages.Repository
{
  public interface IUIRepository
    {
        public List<TodoTask> GetUnfinishedTasks(string Username);
        public List<TodoTask> GetFinishedTasks(string Username);
        public TodoTask GetTaskById(Guid id);
        public bool MarkTaskAsFinished(Guid id);
        public bool MarkTaskAsUnFinished(Guid id);
        public bool DeleteTask(Guid id);
        public bool InsertTask(InputTask task);
        public bool UpdateTask(TodoTask task);
        public bool CheckConnection();
        public bool RegisterNewUser(UserCredentials user);
        public bool Login(UserCredentials user);
  }
}

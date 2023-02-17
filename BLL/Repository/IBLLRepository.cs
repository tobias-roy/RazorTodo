using RazorProject.BLL.Models;
namespace RazorProject.BLL.Repository
{
  public interface IBLLRepository
    {
        public List<TodoTask> GetTodoTasks(); 
    }
}

using RazorProject.DAL.Models;

namespace RazorProject.DAL.Repository
{
  public interface IDALRepository
    {
        public List<TodoTask> GetTasks ();
        public bool InsertTask(TodoTask task);
    }
}

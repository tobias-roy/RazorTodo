using RazorProject.DAL.Models;

namespace RazorProject.DAL.Repository
{
  public interface IDALRepository
    {
        public List<TodoItem> GetTasks ();
    }
}

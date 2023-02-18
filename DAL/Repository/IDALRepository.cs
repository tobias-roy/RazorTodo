using RazorProject.DAL.Models;

namespace RazorProject.DAL.Repository
{
  public interface IDALRepository
    {
        public List<TodoTask> GetUnfinishedTasks ();
        public List<TodoTask> GetFinishedTasks ();
        public bool InsertTask(TodoTask task);
    }
}

using RazorProject.DAL.Models;

namespace RazorProject.DAL.Repository
{
  public interface IDALRepository
    {
        public List<TodoTask> GetUnfinishedTasks ();
        public List<TodoTask> GetFinishedTasks ();
        public bool MarkTaskAsFinished(Guid id);
        public bool MarkTaskAsUnFinished(Guid id);
        public bool InsertTask(TodoTask task);
    }
}

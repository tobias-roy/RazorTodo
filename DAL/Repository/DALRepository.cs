using RazorProject.DAL.Models;

namespace RazorProject.DAL.Repository
{
  public class DALRepository : IDALRepository
    {
        List<TodoItem> taskList = new();

        private List<TodoItem> _GetTasks () {
            return taskList;
        }
        public List<TodoItem> GetTasks () {
            List<TodoItem> dbTaskList = _GetTasks();
            return taskList;
        }
    }
}

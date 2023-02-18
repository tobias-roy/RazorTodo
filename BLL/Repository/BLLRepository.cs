using RazorProject.BLL.Models;
using RazorProject.DAL.Repository;

namespace RazorProject.BLL.Repository
{
  public class BLLRepository : IBLLRepository
    {
        private readonly IDALRepository _dALRepository;
        public BLLRepository(IDALRepository dALRepository){
            _dALRepository = dALRepository;
        }

    public List<TodoTask> GetTodoTasks()
    {
        var dalList = _dALRepository.GetTasks();
        return dalList.Select(o => new TodoTask(o)).ToList();
    }

    // private DAL.Models.TodoTask taskMapper(TodoTask task){
    //   DAL.Models.TodoTask returnTask = new();
    //   returnTask.Description = task.Description;
    //   returnTask.Priority = task.Priority;
    //   returnTask.Completed = task.Completed;
    //   return returnTask;
    // }

    public bool InsertTask(TodoTask bllTask){
      DAL.Models.TodoTask task = new(){
        Description = bllTask.Description,
        Priority = bllTask.Priority,
        Completed = bllTask.Completed
      };

      _dALRepository.InsertTask(task);
      return true;
    }
  }
}

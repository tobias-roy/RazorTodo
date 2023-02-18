using RazorProject.BLL.Repository;
using RazorProject.BLL.Models;

namespace RazorProject.BLL.Controllers
{
  public class TaskListController : ITaskListController
    {
        private readonly IBLLRepository _bLLRepository;

        public TaskListController(IBLLRepository bLLRepository){
            _bLLRepository = bLLRepository;
        }
        
        public List<TodoTask> GetUnfinishedTasks(){
            return _bLLRepository.GetUnfinishedTasks();
        }
        public List<TodoTask> GetFinishedTasks(){
            return _bLLRepository.GetFinishedTasks();
        }

        public bool InsertTask(RazorProject.Pages.Models.TodoTask uiTask){
            BLL.Models.TodoTask task = new(){
            Description = uiTask.Description,
            Priority = uiTask.Priority,
            Completed = uiTask.Completed
        };

        _bLLRepository.InsertTask(task);
        return true;
    }
    }
}


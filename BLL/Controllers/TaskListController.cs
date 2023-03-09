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
        
        public List<TodoTask> GetUnfinishedTasks(string Username){
            return _bLLRepository.GetUnfinishedTasks(Username);
        }
        public List<TodoTask> GetFinishedTasks(string Username){
            return _bLLRepository.GetFinishedTasks(Username);
        }

        public bool InsertTask(RazorProject.Pages.Models.TodoTask uiTask){
            BLL.Models.TodoTask task = new(){
            Description = uiTask.Description,
            Priority = uiTask.Priority,
            Completed = uiTask.Completed,
            Username = uiTask.Username
        };

        _bLLRepository.InsertTask(task);
        return true;
    }
    }
}


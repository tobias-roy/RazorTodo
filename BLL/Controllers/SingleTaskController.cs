using RazorProject.BLL.Repository;
using RazorProject.Pages.Models;

namespace RazorProject.BLL.Controllers
{
  public class SingleTaskController : ISingleTaskController
    {
        private readonly IBLLRepository _bLLRepository;

        public SingleTaskController(IBLLRepository bLLRepository){
            _bLLRepository = bLLRepository;
        }

        private BLL.Models.TodoTask taskMapper(Pages.Models.TodoTask uiTask){
          BLL.Models.TodoTask bllTask = new();
          bllTask.Id = uiTask.Id;
          bllTask.Description = uiTask.Description;
          bllTask.Priority = uiTask.Priority;
          bllTask.Completed = uiTask.Completed;
          return bllTask;
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

    public bool MarkTaskAsFinished(Guid id){
      _bLLRepository.MarkTaskAsFinished(id);
      return true;
    }

    public bool MarkTaskAsUnFinished(Guid id){
      _bLLRepository.MarkTaskAsUnFinished(id);
      return true;
    }

    public bool DeleteTask(Guid id){
      _bLLRepository.DeleteTask(id);
      return true;
    }

    private Pages.Models.TodoTask invertTaskMapper(BLL.Models.TodoTask bllTask){
          Pages.Models.TodoTask uiTask = new();
          uiTask.Id = bllTask.Id;
          uiTask.Description = bllTask.Description;
          uiTask.Priority = bllTask.Priority;
          uiTask.Completed = bllTask.Completed;
          return uiTask;
        }

    public RazorProject.Pages.Models.TodoTask GetTaskById(Guid id)
    {
      return invertTaskMapper(_bLLRepository.GetTaskById(id));
    }

    public bool UpdateTask(TodoTask task)
    {
      _bLLRepository.UpdateTask(taskMapper(task));
      return true;
    }
  }
}


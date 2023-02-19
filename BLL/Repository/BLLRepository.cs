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
    private DAL.Models.TodoTask taskMapper(BLL.Models.TodoTask bllTask){
      DAL.Models.TodoTask dalTask = new();
      dalTask.Id = bllTask.Id;
      dalTask.Description = bllTask.Description;
      dalTask.Priority = bllTask.Priority;
      dalTask.Completed = bllTask.Completed;
      return dalTask;
    }
    public List<TodoTask> GetUnfinishedTasks()
    {
        var dalList = _dALRepository.GetUnfinishedTasks();
        return dalList.Select(o => new TodoTask(o)).ToList();
    }

    public List<TodoTask> GetFinishedTasks()
    {
        var dalList = _dALRepository.GetFinishedTasks();
        return dalList.Select(o => new TodoTask(o)).ToList();
    }

    public bool InsertTask(TodoTask bllTask){
      _dALRepository.InsertTask(taskMapper(bllTask));
      return true;
    }

    public bool MarkTaskAsFinished(Guid id)
    {
      _dALRepository.MarkTaskAsFinished(id);
      return true;
    }

    public bool MarkTaskAsUnFinished(Guid id)
    {
      _dALRepository.MarkTaskAsUnFinished(id);
      return true;
    }

    public bool DeleteTask(Guid id){
      _dALRepository.DeleteTask(id);
      return true;
    }
  }
}

using RazorProject.BLL.Models;
using RazorProject.DAL.Repository;

namespace RazorProject.BLL.Repository
{
  public class BLLRepository : IBLLRepository
  {
    private readonly IDALRepository _dALRepository;
    public BLLRepository(IDALRepository dALRepository)
    {
      _dALRepository = dALRepository;
    }
    private DAL.Models.TodoTask taskMapper(BLL.Models.TodoTask bllTask)
    {
      DAL.Models.TodoTask dalTask = new();
      dalTask.Id = bllTask.Id;
      dalTask.Description = bllTask.Description;
      dalTask.Priority = bllTask.Priority;
      dalTask.Completed = bllTask.Completed;
      dalTask.Username = bllTask.Username;
      return dalTask;
    }
    public List<TodoTask> GetUnfinishedTasks(string Username)
    {
      var dalList = _dALRepository.GetUnfinishedTasks(Username);
      return dalList.Select(o => new TodoTask(o)).ToList();
    }

    public List<TodoTask> GetFinishedTasks(string Username)
    {
      var dalList = _dALRepository.GetFinishedTasks(Username);
      return dalList.Select(o => new TodoTask(o)).ToList();
    }

    public TodoTask GetTaskById(Guid id)
    {
      var daltask = _dALRepository.GetTaskById(id);
      RazorProject.BLL.Models.TodoTask task = new();
      task.Description = daltask.Description;
      task.CreatedTime = daltask.CreatedTime;
      task.Id = daltask.Id;
      task.Priority = daltask.Priority;
      task.Completed = daltask.Completed;
      task.Username = daltask.Username;
      return task;
    }

    public bool InsertTask(TodoTask bllTask)
    {
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

    public bool DeleteTask(Guid id)
    {
      _dALRepository.DeleteTask(id);
      return true;
    }

    public bool UpdateTask(TodoTask todoTask)
    {
      _dALRepository.UpdateTask(taskMapper(todoTask));
      return true;
    }

    public bool CheckConnection()
    {
      return _dALRepository.CheckConnection();
    }

    public bool CreateNewUser(UserCredentials bllUser)
    {
      return _dALRepository.CreateNewUser(bllUser);
    }

    public bool Login(UserCredentials bllUser)
    {
      return _dALRepository.Login(bllUser);
    }
  }
}

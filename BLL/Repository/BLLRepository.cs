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
  }
}

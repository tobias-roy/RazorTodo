using RazorProject.BLL.Models;
using RazorProject.DAL.Repository;

namespace RazorProject.BLL.Repository
{
  public class BLLRepository : IBLLRepository
    {
        public IDALRepository _dALRepository;
        public BLLRepository(IDALRepository dALRepository){
            _dALRepository = dALRepository;
        }

    public List<TodoItem> GetTodoItems()
    {
        List<TodoItem> dalItems = _dALRepository.GetTasks();
      return 
    }
  }
}

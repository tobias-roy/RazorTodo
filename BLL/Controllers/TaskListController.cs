using RazorProject.BLL.Repository;

namespace RazorProject.BLL.Controllers
{
  public class TaskListController : ITaskListController
    {
        private readonly IBLLRepository _bLLRepository;

        public TaskListController(IBLLRepository bLLRepository){
            _bLLRepository = bLLRepository;
        }
        
        public string GetListOfTasks(){
            var testList = _bLLRepository.GetTodoTasks();
            return testList.FirstOrDefault().Description;
        }



    }
}

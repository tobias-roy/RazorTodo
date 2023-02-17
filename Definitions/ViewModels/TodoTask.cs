using RazorProject.BLL.Models;

namespace RazorProject.Definitions.ViewModels
{
  public class TodoTaskViewModel
    {
        public DateTime CreatedTime { get; set; }
        public String Description { get; set; }
        public Priority Priority { get; set; }
        public Boolean Completed { get; set; }

        public TodoTaskViewModel (TodoTask todoTask){
            CreatedTime = todoTask.CreatedTime;
            Description = todoTask.Description;
            Priority = todoTask.Priority;
            Completed = todoTask.Completed;
        }
    }
}

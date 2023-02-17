using RazorProject.Definitions;

namespace RazorProject.BLL.Models
{
  public class TodoTask
    {
        public DateTime CreatedTime { get; set; }
        public String Description { get; set; }
        public Priority Priority { get; set; }
        public Boolean Completed { get; set; }

        public TodoTask (DAL.Models.TodoTask todoItem){
            CreatedTime = todoItem.CreatedTime;
            Description = todoItem.Description;
            Priority = todoItem.Priority;
            Completed = todoItem.Completed;
        }
    }
}

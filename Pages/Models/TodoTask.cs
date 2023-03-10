using System.ComponentModel.DataAnnotations;
using RazorProject.Definitions;

namespace RazorProject.Pages.Models
{
  public class TodoTask
  {
    public Guid Id { get; set; }
    public DateTime CreatedTime { get; set; }
    [Required][MaxLength(25)]
    public String Description { get; set; }
    public Priority Priority { get; set; }
    public Boolean Completed { get; set; }
    public String Username { get; set; }

    public TodoTask (BLL.Models.TodoTask todoItem){
        Id = todoItem.Id;
        CreatedTime = todoItem.CreatedTime;
        Description = todoItem.Description;
        Priority = todoItem.Priority;
        Completed = todoItem.Completed;
        Username = todoItem.Username;
    }

    public TodoTask()
    {
    }
  }
}

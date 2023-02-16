namespace RazorProject.DAL.Models
{
  public class TodoItem
    {
        Guid Id { get; set; }
        DateTime CreatedTime { get; set; }
        String Description { get; set; }
        Priority Priority { get; set; }
        Boolean Completed { get; set; }
    }

    public enum Priority {
        Low,
        Medium,
        High
    }
}

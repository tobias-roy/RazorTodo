using RazorProject.Definitions;

namespace RazorProject.DAL.Models
{
  public class TodoTask
    {
        public Guid Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public String Description { get; set; }
        public Priority Priority { get; set; }
        public Boolean Completed { get; set; }
    }
}

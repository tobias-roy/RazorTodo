using System.ComponentModel.DataAnnotations;
using RazorProject.Definitions;

namespace RazorProject
{
  public class InputTask
    {
      [Required][MaxLength(25)]
      public String Description { get; set; }
      public Priority Priority { get; set; } = Priority.Medium;
    }
}

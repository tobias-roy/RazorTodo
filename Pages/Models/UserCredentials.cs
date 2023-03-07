using System.ComponentModel.DataAnnotations;


namespace RazorProject.Pages.Models
{
  public class UserCredentials
    {
      [Required][MaxLength(12)]
      public String Username { get; set; }
      
      [Required][MaxLength(25)]
      public String Password { get; set; }
    }
}

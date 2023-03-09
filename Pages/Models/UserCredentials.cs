using System.ComponentModel.DataAnnotations;


namespace RazorProject.Pages.Models
{
  public class UserCredentials
    {
      [Required, MinLength(3), MaxLength(12)]
      public String Username { get; set; }
      
      [Required, MinLength(5), MaxLength(25)]
      public String Password { get; set; }
    }
}

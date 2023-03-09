using RazorProject.Pages.Models;

namespace RazorProject.BLL.Controllers
{
  public interface IUserController
  {
    public bool CreateNewUser(RazorProject.Pages.Models.UserCredentials user);
    public bool Login(UserCredentials user);
  }
}


using RazorProject.Pages.Models;

namespace RazorProject.BLL.Controllers
{
  public interface IUserController
  {
      void CreateNewUser(RazorProject.Pages.Models.UserCredentials user);
    public bool Login(UserCredentials user);
  }
}


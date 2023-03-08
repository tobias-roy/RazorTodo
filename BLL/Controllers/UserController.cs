using RazorProject.BLL.Repository;
using RazorProject.Pages.Models;

namespace RazorProject.BLL.Controllers
{
  public class UserController : IUserController
  {
    private readonly IBLLRepository _bLLRepository;

    public UserController(IBLLRepository bLLRepository)
    {
      _bLLRepository = bLLRepository;
    }


    public bool CreateNewUser(Pages.Models.UserCredentials user)
    {
      BLL.Models.UserCredentials bllUser = new();
      bllUser.Username = user.Username;
      bllUser.Password = user.Password;
      return _bLLRepository.CreateNewUser(bllUser);
    }

    public bool Login(UserCredentials user)
    {
      BLL.Models.UserCredentials bllUser = new();
      bllUser.Username = user.Username;
      bllUser.Password = user.Password;
      return _bLLRepository.Login(bllUser);
    }
  }
}


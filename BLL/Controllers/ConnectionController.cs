using RazorProject.BLL.Repository;

namespace RazorProject.BLL.Controllers
{
  public class ConnectionController : IConnectionController
    {
        private readonly IBLLRepository _bLLRepository;

        public ConnectionController(IBLLRepository bLLRepository){
            _bLLRepository = bLLRepository;
        }

    public bool CheckConnection()
    {
      return _bLLRepository.CheckConnection();
    }
  }
}


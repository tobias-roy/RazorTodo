using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProject.BLL.Controllers;
using RazorProject.Pages.Repository;

namespace RazorProject.Pages;

public class LoginModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IUIRepository _uiRepository;

    public LoginModel(ILogger<IndexModel> logger, ITaskListController taskListController, IUIRepository uiRepository) {
        _logger = logger;
        _uiRepository = uiRepository;
    }

    public void OnGet() {
    }

    public bool CheckConnection(){
        return _uiRepository.CheckConnection();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProject.BLL.Controllers;
using RazorProject.Pages.Repository;

namespace RazorProject.Pages;

public class RegisterModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IUIRepository _uiRepository;

    public RegisterModel(ILogger<IndexModel> logger, ITaskListController taskListController, IUIRepository uiRepository) {
        _logger = logger;
        _uiRepository = uiRepository;
    }

    public void OnGet() {
    }

    public IActionResult OnPostRegisterUser(string username, string password){
        // _uiRepository.RegisterUser(username, password);
        return Page();
    }

    public bool CheckConnection(){
        return _uiRepository.CheckConnection();
    }
}

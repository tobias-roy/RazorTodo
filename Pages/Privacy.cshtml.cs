using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProject.Pages.Models;
using RazorProject.Pages.Repository;

namespace RazorProject.Pages;

public class PrivacyModel : PageModel
{
    private readonly ILogger<PrivacyModel> _logger;
    private readonly IUIRepository _uiRepository;

    public PrivacyModel(ILogger<PrivacyModel> logger, IUIRepository uiRepository) {
        _logger = logger;
        _uiRepository = uiRepository;
    }

    public void OnGet()
    {
    }

    public List<TodoTask> GetFinishedTasks () {
        var listOfTasks = _uiRepository.GetFinishedTasks();
        return listOfTasks;
    }

}


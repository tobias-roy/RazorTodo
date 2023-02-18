using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProject.BLL.Controllers;
using RazorProject.Pages.Models;
using RazorProject.Pages.Repository;

namespace RazorProject.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly IUIRepository _uiRepository;

    public IndexModel(ILogger<IndexModel> logger, ITaskListController taskListController, IUIRepository uiRepository) {
        _logger = logger;
        _uiRepository = uiRepository;
    }

    public void OnGet() {
    }

    public List<TodoTask> GetUnfinishedTasks () {
        var listOfTasks = _uiRepository.GetUnfinishedTasks();
        return listOfTasks;
    }

    public IActionResult OnPostAddOnClick(){
        
        return Page();
    }
}

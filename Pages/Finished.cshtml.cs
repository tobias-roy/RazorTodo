using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProject.Pages.Models;
using RazorProject.Pages.Repository;

namespace RazorProject.Pages;

public class UnfinishedModel : PageModel
{
    private readonly ILogger<UnfinishedModel> _logger;
    private readonly IUIRepository _uiRepository;

    public UnfinishedModel(ILogger<UnfinishedModel> logger, IUIRepository uiRepository) {
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

    public IActionResult OnPostMarkAsUnFinished(Guid id){
        _uiRepository.MarkTaskAsUnFinished(id);
        return Page();
    }

    public IActionResult OnPostDelete(Guid id){
        _uiRepository.DeleteTask(id);
        return Page();
    }

}


using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorProject.BLL.Controllers;

namespace RazorProject.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ITaskListController _taskListController;

    public IndexModel(ILogger<IndexModel> logger, ITaskListController taskListController) {
        _logger = logger;
        _taskListController = taskListController;
    }

    public void OnGet() {
        
    }

    public string GetString () {
        return _taskListController.GetListOfTasks();
    }
}

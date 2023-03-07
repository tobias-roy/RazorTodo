using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorProject.BLL.Controllers;
using RazorProject.Pages.Models;
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

    public List<TodoTask> GetUnfinishedTasks () {
        var listOfTasks = _uiRepository.GetUnfinishedTasks();
        return listOfTasks;
    }

    public IActionResult OnPostMarkAsFinished(Guid id){
        _uiRepository.MarkTaskAsFinished(id);
        return Page();
    }

    public PartialViewResult OnGetAddTaskPartial(){
        return new PartialViewResult{
            ViewName = "_AddTaskPartial",
            ViewData = new ViewDataDictionary<InputTask>(ViewData, new InputTask{})
        };
    }

    public PartialViewResult OnPostTaskInputPartial(InputTask task){
        if(ModelState.IsValid){
            _uiRepository.InsertTask(task);
        }

        return new PartialViewResult{
            ViewName = "_AddTaskPartial",
            ViewData = new ViewDataDictionary<InputTask>(ViewData, task)
        };
    }

    public PartialViewResult OnPostEditTaskPartial(TodoTask task){
        if(ModelState.IsValid){
            _uiRepository.UpdateTask(task);
        }

        return new PartialViewResult{
            ViewName = "_EditTaskPartial",
            ViewData = new ViewDataDictionary<TodoTask>(ViewData, task)
        };
    }

    public PartialViewResult OnGetEditTaskPartial(Guid id){
        TodoTask task = _uiRepository.GetTaskById(id);
        
        return new PartialViewResult{
            ViewName = "_EditTaskPartial",
            ViewData = new ViewDataDictionary<TodoTask>(ViewData, task)
        };
    }

    public bool CheckConnection(){
        return _uiRepository.CheckConnection();
    }
}

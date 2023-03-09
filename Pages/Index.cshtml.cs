using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using RazorProject.BLL.Controllers;
using RazorProject.Pages.Models;
using RazorProject.Pages.Repository;

namespace RazorProject.Pages;

public class IndexModel : PageModel
{
    public bool LoggedInStatus {get;set;}
    private readonly ILogger<IndexModel> _logger;
    private readonly IUIRepository _uiRepository;

    public IndexModel(ILogger<IndexModel> logger, ITaskListController taskListController, IUIRepository uiRepository) {
        _logger = logger;
        _uiRepository = uiRepository;
    }

    public void OnGet() {
        if(string.IsNullOrEmpty(HttpContext.Session.GetString("_LoggedIn"))){
            LoggedInStatus = false;
        } else {
            LoggedInStatus = true;
        }
    }

    public List<TodoTask> GetUnfinishedTasks (string Username) {
        var listOfTasks = _uiRepository.GetUnfinishedTasks(Username);
        return listOfTasks;
    }

    public IActionResult OnPostMarkAsFinished(Guid id){
        _uiRepository.MarkTaskAsFinished(id);
        return Page();
    }

     public IActionResult OnPostLogout(){
        HttpContext.Session.SetString("_LoggedIn", "");
        return RedirectToPage("Index");
    }

    public PartialViewResult OnGetAddTaskPartial(){
        return new PartialViewResult{
            ViewName = "_AddTaskPartial",
            ViewData = new ViewDataDictionary<InputTask>(ViewData, new InputTask{})
        };
    }

    public PartialViewResult OnGetRegisterUserPartial(){
        return new PartialViewResult{
            ViewName = "_RegisterUserPartial",
            ViewData = new ViewDataDictionary<UserCredentials>(ViewData, new UserCredentials{})
        };
    }

    public PartialViewResult OnPostRegisterNewUserPartial(UserCredentials user){
        var status = 401;
        if(ModelState.IsValid){
            if(_uiRepository.RegisterNewUser(user)){
                status = 200;
            } else {
                status = 400;
            }
        }

        return new PartialViewResult{
            ViewName = "_RegisterUserPartial",
            ViewData = new ViewDataDictionary<UserCredentials>(ViewData, user),
            StatusCode = status
        };
    }

    public PartialViewResult OnGetLoginUserPartial(){
        return new PartialViewResult{
            ViewName = "_LoginUserPartial",
            ViewData = new ViewDataDictionary<UserCredentials>(ViewData, new UserCredentials{})
        };
    }

    public PartialViewResult OnPostAttemptLoginUserPartial(UserCredentials user){
        var status = 401;
        if(ModelState.IsValid){
            if(_uiRepository.Login(user)){
                HttpContext.Session.SetString("_LoggedIn", $"{user.Username}");
                status = 200;
            } else {
                HttpContext.Session.SetString("_LoggedIn", "");
                status = 400;
            }
        }

        return new PartialViewResult{
            ViewName = "_LoginUserPartial",
            ViewData = new ViewDataDictionary<UserCredentials>(ViewData, user),
            StatusCode = status
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

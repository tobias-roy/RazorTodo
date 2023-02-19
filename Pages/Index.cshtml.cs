﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
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
}

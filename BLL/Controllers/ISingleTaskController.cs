namespace RazorProject.BLL.Controllers
{
  public interface ISingleTaskController
    { 
        public bool InsertTask(RazorProject.Pages.Models.TodoTask uiTask);
        public bool MarkTaskAsFinished(Guid id);
        public bool MarkTaskAsUnFinished(Guid id);
        public bool DeleteTask(Guid id);
    }
}

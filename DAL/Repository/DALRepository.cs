using RazorProject.DAL.Models;

namespace RazorProject.DAL.Repository
{
  public class DALRepository : IDALRepository
    {
        List<TodoTask> taskList;
        public DALRepository(){
            taskList = new(){
                new TodoTask(){
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    Description = "Hent Fiskmad",
                    Priority = Definitions.Priority.Medium,
                    Completed = false
                },
                new TodoTask(){
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    Description = "Hent Kattemad",
                    Priority = Definitions.Priority.Medium,
                    Completed = false
                },
                new TodoTask(){
                    Id = Guid.NewGuid(),
                    CreatedTime = DateTime.Now,
                    Description = "Hent Hundemad",
                    Priority = Definitions.Priority.Medium,
                    Completed = false
                }
            };
        }
        public List<TodoTask> GetTasks () {
            return taskList;
        }
    }
}

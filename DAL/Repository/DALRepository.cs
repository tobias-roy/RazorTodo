using RazorProject.DAL.Models;

namespace RazorProject.DAL.Repository
{
  public class DALRepository : IDALRepository
    {

        public bool InsertTask(TodoTask task){
            Guid newId = Guid.NewGuid();
            int booleanValue = task.Completed ? 1 : 0;
            using (var connection = Database.getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = 
                @$"INSERT INTO Task
                VALUES ('{newId}', '{DateTime.UtcNow}', '{task.Description}', '{(int)task.Priority}', '{booleanValue}');";
                command.ExecuteNonQuery();
            }
            return true;
        }

        public List<TodoTask> GetTasks () {
            List<TodoTask> taskList = new();
            using (var connection = Database.getConnection()){
                var command = connection.CreateCommand();
                command.CommandText = 
                @$"SELECT * FROM Task";
                var reader = command.ExecuteReader();
                while(reader.Read()){
                    TodoTask task = new();
                    task.Id = (Guid)reader.GetSqlGuid(0);
                    task.CreatedTime = reader.GetDateTime(1);
                    task.Description = reader.GetString(2);
                    task.Priority = (Definitions.Priority)reader.GetInt16(3);
                    var boolValue = reader.GetInt16(4);
                    if(boolValue == 1){
                        task.Completed = true;
                    } else {
                        task.Completed = false;
                    }
                    taskList.Add(task);
                }
            }
            return taskList;
        }
    }
}

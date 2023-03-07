using RazorProject.DAL.Models;
namespace RazorProject.DAL.Repository
{
  public class DALRepository : IDALRepository
  {

    public bool InsertTask(TodoTask task)
    {
      Guid newId = Guid.NewGuid();
      int booleanValue = task.Completed ? 1 : 0;
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText =
        @$"INSERT INTO Task (Id, CreatedTime, Description, Priority, Completed)
                VALUES ('{newId}', GETDATE(), '{task.Description}', '{(int)task.Priority}', '{booleanValue}');";
        command.ExecuteNonQuery();
      }
      return true;
    }

    public bool MarkTaskAsFinished(Guid id)
    {
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText =
        @$"UPDATE Task
                SET Completed = 1
                WHERE Id = '{id}'";
        command.ExecuteNonQuery();
      }
      return true;
    }

    public bool MarkTaskAsUnFinished(Guid id)
    {
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText =
        @$"UPDATE Task
                SET Completed = 0
                WHERE Id = '{id}'";
        command.ExecuteNonQuery();
      }
      return true;
    }

    public bool DeleteTask(Guid id)
    {
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText =
        @$"DELETE FROM Task WHERE Id = '{id}'";
        command.ExecuteNonQuery();
      }
      return true;
    }

    public List<TodoTask> GetUnfinishedTasks()
    {
      List<TodoTask> taskList = new();
      try
      {
        using (var connection = Database.getConnection())
        {
          var command = connection.CreateCommand();
          command.CommandText =
          @$"SELECT * FROM Task WHERE Completed = 0 ORDER BY CreatedTime DESC";
          var reader = command.ExecuteReader();
          while (reader.Read())
          {
            TodoTask task = new();
            task.Id = (Guid)reader.GetSqlGuid(0);
            task.CreatedTime = reader.GetDateTime(1);
            task.Description = reader.GetString(2);
            task.Priority = (Definitions.Priority)reader.GetInt16(3);
            task.Completed = false;
            taskList.Add(task);
          }
        }
      }
      catch
      {

      }
      return taskList;
    }

    public List<TodoTask> GetFinishedTasks()
    {
      List<TodoTask> taskList = new();
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText =
        @$"SELECT * FROM Task WHERE Completed = 1 ORDER BY CreatedTime DESC";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
          TodoTask task = new();
          task.Id = (Guid)reader.GetSqlGuid(0);
          task.CreatedTime = reader.GetDateTime(1);
          task.Description = reader.GetString(2);
          task.Priority = (Definitions.Priority)reader.GetInt16(3);
          task.Completed = true;
          taskList.Add(task);
        }
      }
      return taskList;
    }

    public TodoTask GetTaskById(Guid id)
    {
      TodoTask task = new();
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText =
        @$"SELECT * FROM Task WHERE Id = '{id}'";
        var reader = command.ExecuteReader();
        reader.Read();
        task.Id = (Guid)reader.GetSqlGuid(0);
        task.CreatedTime = reader.GetDateTime(1);
        task.Description = reader.GetString(2);
        task.Priority = (Definitions.Priority)reader.GetInt16(3);
        task.Completed = false;
      }
      return task;
    }

    public bool UpdateTask(TodoTask todoTask)
    {
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText =
        @$"UPDATE Task
            SET Description = '{todoTask.Description}', Priority = '{(int)todoTask.Priority}'
            WHERE Id = '{todoTask.Id}'";
        command.ExecuteNonQuery();
      }
      return true;
    }

    public bool CheckConnection()
    {
      return Database.CheckConnection();
    }

    public void CreateNewUser(BLL.Models.UserCredentials bllUser)
    {
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText = @$"DECLARE @responseMessage NVARCHAR(250)
        EXEC dbo.addNewUser
          @pUserName = N'{bllUser.Username}',
          @pPassword = N'{bllUser.Password}',
          @responseMessage=@responseMessage OUTPUT";
        command.ExecuteNonQuery();
      }
    }
  }
}

using RazorProject.DAL.Models;

namespace RazorProject.DAL.Repository
{
  public class DALRepository : IDALRepository
  {
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

    public bool CreateNewUser(BLL.Models.UserCredentials bllUser)
    {
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText = @$"DECLARE @responseMessage VARCHAR(5)
        EXEC uspRegisterNewUser
          @pUserName = '{bllUser.Username}',
          @pPassword = '{bllUser.Password}',
          @responseMessage=@responseMessage OUTPUT
          SELECT  @responseMessage as N'@responseMessage'";
        Boolean.TryParse((string)command.ExecuteScalar(), out bool result);
        return result;
      }
    }

    public bool Login(BLL.Models.UserCredentials bllUser)
    {
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText = @$"DECLARE @responseMessage nvarchar(5)
        EXEC    uspUserLogin
        @pUsername = '{bllUser.Username}',
        @pPassword = '{bllUser.Password}',
        @responseMessage = @responseMessage OUTPUT
        SELECT  @responseMessage as N'@responseMessage'";
        Boolean.TryParse((string)command.ExecuteScalar(), out bool result);
        return result;
      }
    }

    public bool InsertTask(TodoTask task)
    {
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText = @$"DECLARE @responseMessage nvarchar(5)
        EXEC    uspCreateTask
        @pDescription = '{task.Description}',
        @pPriority = '{(int)task.Priority}',
        @pUsername = '{task.Username}',
        @responseMessage = @responseMessage OUTPUT
        SELECT  @responseMessage as N'@responseMessage'";
        Boolean.TryParse((string)command.ExecuteScalar(), out bool result);
        return result;
      }
    }

    public bool MarkTaskAsFinished(Guid id)
    {
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText = @$"DECLARE @responseMessage nvarchar(5)
        EXEC    uspMarkTodoAsDone
        @pTodoID = '{id}',
        @responseMessage = @responseMessage OUTPUT
        SELECT  @responseMessage as N'@responseMessage'";
        Boolean.TryParse((string)command.ExecuteScalar(), out bool result);
        return result;
      }
    }

    public bool MarkTaskAsUnFinished(Guid id)
    {
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText = @$"DECLARE @responseMessage nvarchar(5)
        EXEC    uspMarkTodoAsUndone
        @pTodoID = '{id}',
        @responseMessage = @responseMessage OUTPUT
        SELECT  @responseMessage as N'@responseMessage'";
        Boolean.TryParse((string)command.ExecuteScalar(), out bool result);
        return result;
      }
    }

    public List<TodoTask> GetUnfinishedTasks(string Username)
    {
      List<TodoTask> taskList = new();
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText =
        @$"EXEC uspGetUnfinishedTodos
          @pUsername = '{Username}'";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
          TodoTask task = new();
          task.Id = (Guid)reader.GetSqlGuid(0);
          task.Description = reader.GetString(1);
          task.CreatedTime = reader.GetDateTime(2);
          task.Priority = (Definitions.Priority)reader.GetInt16(3);
          task.Completed = Boolean.TryParse(reader.GetString(4), out bool result);
          taskList.Add(task);
        }
      }
      return taskList;
    }

    public List<TodoTask> GetFinishedTasks(string Username)
    {
      List<TodoTask> taskList = new();
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText =
        @$"EXEC uspGetFinishedTodos
          @pUsername = '{Username}'";
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
          TodoTask task = new();
          task.Id = (Guid)reader.GetSqlGuid(0);
          task.Description = reader.GetString(1);
          task.CreatedTime = reader.GetDateTime(2);
          task.Priority = (Definitions.Priority)reader.GetInt16(3);
          task.Completed = Boolean.TryParse(reader.GetString(4), out bool result);
          taskList.Add(task);
        }
      }
      return taskList;
    }

    public bool DeleteTask(Guid id)
    {
      using (var connection = Database.getConnection())
      {
        var command = connection.CreateCommand();
        command.CommandText = @$"DECLARE @responseMessage nvarchar(5)
        EXEC uspDeleteFinishedTodoItem
        @pTodoID = '{id}',
        @responseMessage = @responseMessage OUTPUT
        SELECT  @responseMessage as '@responseMessage'";
        Boolean.TryParse((string)command.ExecuteScalar(), out bool result);
        return result;
      }
    }
  }
}

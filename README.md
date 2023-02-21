# RazorTodo
RazorTodo is a school project with focus on building a todo list application using Razor Pages in ASP.NET Core. <br>
Reference: [Razor Documentation](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio)
## Dependencies
#### Packages
Make sure you are using [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient) Version 4.8.5 or newer.
#### Docker
This project is using [Docker](https://www.docker.com/). To install docker desktop follow the guide for your operating system below. <br>
[MacOS](https://docs.docker.com/desktop/install/mac-install/) 
[Linux](https://docs.docker.com/desktop/install/linux-install/) 
[Windows](https://docs.docker.com/desktop/install/windows-install/)


#### Database
This project is currently set up to use a [Azure Sql Edge database](https://hub.docker.com/_/microsoft-azure-sql-edge) running in a docker container. <br>
To initialize the container run the following command:
```
docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=P@ssw0rd' -p 1433:1433 --name RazorTodoDatabase -d mcr.microsoft.com/azure-sql-edge
```
Connect to the database via your prefered interface, use the info:
- Server: localhost
- Authentication Type: SQL Login
- User name: SA
- Password: P@ssw0rd
<br>
Run the following query to create the database:

```
  CREATE DATABASE TodoDb;
  CREATE TABLE Task (Id UNIQUEIDENTIFIER PRIMARY KEY, CreatedTime DATETIME, Description VARCHAR(25), Priority SMALLINT, Completed SMALLINT);
```


With this command it's possible to connect to the database with the following connection string:
```
SqlConnectionStringBuilder sb = new(){
  DataSource = "localhost",
  InitialCatalog = "TodoDb",
  UserID = "SA",
  Password = "P@ssw0rd"
};
```

# RazorTodo
RazorTodo is a school project with focus on building a todo list application using Razor Pages in ASP.NET Core. <br>
Reference: [Razor Documentation](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio)
## Dependencies
#### Packages
Make sure you are using [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient) Version 4.8.5 or newer. <br>
Navigate to the project folder and run the following command:
```
dotnet add package System.Data.SqlClient --version 4.8.5
```
#### Docker
This project is using [Docker](https://www.docker.com/). To install docker desktop follow the guide for your operating system below. <br>
[MacOS](https://docs.docker.com/desktop/install/mac-install/) 
[Linux](https://docs.docker.com/desktop/install/linux-install/) 
[Windows](https://docs.docker.com/desktop/install/windows-install/)


#### Database
This project is currently set up to use a [Azure Sql Edge database](https://hub.docker.com/_/microsoft-azure-sql-edge) running in a docker container. <br>
If you wish to persist the database make sure you create a volume.

```
docker volume create tododb
```

To initialize the container run the following command:

```
docker run --cap-add SYS_PTRACE -e 'ACCEPT_EULA=1' -e 'MSSQL_SA_PASSWORD=P@ssw0rd' -p 1433:1433 --mount type=volume,src=tododb,target=tasks --name RazorTodoDatabase -d mcr.microsoft.com/azure-sql-edge
```

Connect to the database via your prefered interface, use the info:
- Server: localhost
- Authentication Type: SQL Login
- User name: SA
- Password: P@ssw0rd
<br>
Modify the path and container_id and run the following command to copy the database to the docker container:

```sql
  docker cp /path/Database-Restoration.bak container_id:/Database-Restoration.bak
```
Using [Azure Data Studio](https://learn.microsoft.com/en-us/sql/azure-data-studio/download-azure-data-studio?view=sql-server-ver16&tabs=redhat-install%2Credhat-uninstall) or a similair software connect to your SQL Server (Docker container) and restore the Database-Restoration.bak database.

With this command it's possible to connect and use the database correctly with the following connection string:

```c#
SqlConnectionStringBuilder sb = new(){
  DataSource = "localhost",
  InitialCatalog = "TodoDatabase",
  UserID = "SA",
  Password = "P@ssw0rd"
};
```

## Usage
#### Development
Navigate to the project folder using a terminal and run the following command:

```
dotnet run
```
Open a webbrowser and navigate to http://localhost:5173

#### Production
```
Don't
```

## Future development
#### Error handling on submit
Currently version 1.2 only supports errorhandling on main page loads - We plan to expand this to also handle a faulty connection on a task submit, edit or delete.

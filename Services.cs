using RazorProject.BLL.Controllers;
using RazorProject.BLL.Repository;
using RazorProject.DAL.Repository;
using RazorProject.Pages.Repository;

namespace RazorProject
{
  public static class ServicesExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services){
            services.AddSingleton<IDALRepository, DALRepository>();
            services.AddSingleton<IBLLRepository, BLLRepository>();
            services.AddSingleton<IUIRepository, UIRepository>();
            services.AddSingleton<ITaskListController, TaskListController>();
            services.AddSingleton<ISingleTaskController, SingleTaskController>();
            services.AddSingleton<IConnectionController, ConnectionController>();
            services.AddSingleton<IUserController, UserController>();
            return services;
        }    
    }
}

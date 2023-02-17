using RazorProject.BLL.Controllers;
using RazorProject.BLL.Repository;
using RazorProject.DAL.Repository;

namespace RazorProject
{
  public static class ServicesExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services){
            services.AddSingleton<IDALRepository, DALRepository>();
            services.AddSingleton<IBLLRepository, BLLRepository>();
            services.AddSingleton<ITaskListController, TaskListController>();
            return services;
        }    
    }
}

using WebApplication3CURDWithDapperCore6MVC_Demo.Models;

namespace WebApplication3CURDWithDapperCore6MVC_Demo.Repositories
{
	public interface ITaskRepository
	{
		Task<IEnumerable<TaskEntity>> GetTaskEntity();
		Task<TaskEntity> GetTask(int? id);
		Task CreateTask(TaskEntity taskEntity);
		Task UpdateTask(int id, TaskEntity taskEntity);
		Task DeleteTask(int id);
	}
}
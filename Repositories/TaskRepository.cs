using WebApplication3CURDWithDapperCore6MVC_Demo.DBContext;
using WebApplication3CURDWithDapperCore6MVC_Demo.Models;
using Dapper;
using System.Data;

namespace WebApplication3CURDWithDapperCore6MVC_Demo.Repositories
{
	public class TaskRepository : ITaskRepository
	{
		private readonly DapperContext context;

		//public TaskRepository(DapperContext context)
		//{
		//	this.context = context;
		//}
        public TaskRepository()
        {
            this.context = new DapperContext();
        }

        public async Task<IEnumerable<TaskEntity>> GetTaskEntity()
		{
			var query = "SELECT * FROM TaskEntity";

			using (var connection = context.CreateConnection())
			{
				var companies = await connection.QueryAsync<TaskEntity>(query);
				return companies.ToList();
			}
		}

		public async Task<TaskEntity> GetTask(int? id)
		{
			var query = "SELECT * FROM TaskEntity WHERE Id = @Id";

			using (var connection = context.CreateConnection())
			{
				var taskEntity = await connection.QuerySingleOrDefaultAsync<TaskEntity>(query, new { id });
				return taskEntity;
			}
		}

		public async Task CreateTask(TaskEntity taskEntity)
		{
			try
			{
				var query = "INSERT INTO TaskEntity (Name, description, status) VALUES (@Name, @description, @status)";

				var parameters = new DynamicParameters();
				parameters.Add("Name", taskEntity.Name, DbType.String);
				parameters.Add("description", taskEntity.Description, DbType.String);
				parameters.Add("status", taskEntity.Status, DbType.String);

				using (var connection = context.CreateConnection())
				{
					await connection.ExecuteAsync(query, parameters);
				}
			}
			catch (Exception ex)
			{
				throw ;
			}
		}

		public async Task UpdateTask(int id, TaskEntity taskEntity)
		{
			try
			{ 
				var query = "update  TaskEntity set Name=@Name, description=@description, status=@status WHERE Id = @Id";
				var parameters = new DynamicParameters();
				parameters.Add("Name", taskEntity.Name, DbType.String);
				parameters.Add("description", taskEntity.Description, DbType.String);
				parameters.Add("status", taskEntity.Status, DbType.String);
				parameters.Add("Id", id, DbType.Int16);
				using (var connection = context.CreateConnection())
				{
					await connection.ExecuteAsync(query, parameters);
				}
            }
            catch (Exception ex)
            {
                throw;
            }
        }
		public async Task DeleteTask(int id)
		{
			try
			{
				var query = "DELETE FROM TaskEntity WHERE Id = @Id";
				using (var connection = context.CreateConnection())
				{
					await connection.ExecuteAsync(query, new { id });
				}
            }
            catch (Exception ex)
            {
                throw;
            }

        }
	}
}
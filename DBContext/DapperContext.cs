
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace WebApplication3CURDWithDapperCore6MVC_Demo.DBContext
{
	public class DapperContext
	{
		private readonly string _connectionString;       
        
        public DapperContext()
        {
            var configurations = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            _connectionString = configurations["ConnectionStrings:DefaultConnection"];            
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
	}
}
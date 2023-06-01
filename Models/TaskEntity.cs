using System.ComponentModel.DataAnnotations;

namespace WebApplication3CURDWithDapperCore6MVC_Demo.Models
{
	public class TaskEntity
	{
		public int ID { get; set; }

		[Display(Name = "Name")]
		public string Name { get; set; }

		[Display(Name = "description")]
		public string Description { get; set; }

		public string Status { get; set; }


	}
}
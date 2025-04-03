using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHub.TaskHub.Model
{
	public class TaskItem
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public DateTime DueDate { get; set; }
		[ForeignKey("Category")]
		public int UserId { get; set; }
		[Required]
		public bool IsCompleted { get; set; }
	}

}

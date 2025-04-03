using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHub.TaskHub.Model
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		[Required]
		public string Name { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskHub.TaskHub.Model
{
	public class User
	{
		[Key]
		public int UserId { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[DataType(DataType.Password)]
		public string password {  get; set; }

		[ForeignKey("Role")]
		public int RoleId { get; set; }

		public Role Role { get; set; }
	}
}

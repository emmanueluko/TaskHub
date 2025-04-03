using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskHub.TaskHub.Model;


namespace TaskHub.TaskHub
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelbuilder)
		{

			base.OnModelCreating(modelbuilder);

			foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{

				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}

			modelbuilder.Entity<TaskItem>().ToTable(nameof(TaskItem));
			modelbuilder.Entity<Category>().ToTable(nameof(Category));
			modelbuilder.Entity<Role>().ToTable(nameof(Role));
			modelbuilder.Entity<User>().ToTable(nameof(User));
			modelbuilder.Entity<LoginDto>().ToTable(nameof(LoginDto));
			modelbuilder.Entity<RegisterDto>().ToTable(nameof(RegisterDto));


		}

		//public DbSet<YourEntity> YourEntities { get; set; }
		public DbSet<TaskItem> Tasks { get; set; }
		public DbSet<LoginDto> Login{ get; set; }
		public DbSet<RegisterDto> Register{ get; set; }
		public DbSet<Category> Category{ get; set; }
		public DbSet<Role> Role{ get; set; }
		public DbSet<User> Users { get; set; }
	}
}

using Microsoft.EntityFrameworkCore;

namespace Personal_Department_AspNetCoreMVC.Models
{
	public class Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server= (localdb)\\Mehmet; Database=CompanyPersonals; Integrated Security=True;");
		}
		public DbSet<Department> DepartmentsDb { get; set; }
		public DbSet<Personal> PersonalsDb { get; set; }
		public DbSet<Admin> Admins { get; set; }
	}
}

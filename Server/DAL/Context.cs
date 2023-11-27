using Microsoft.EntityFrameworkCore;
using Prueba.Shared;

namespace Prueba.Server.DAL
{
	public class Context : DbContext
	{
		public Context(DbContextOptions<Context> options) 
			:base(options) { }

		public DbSet<Usuarios> Usuarios { get; set; }
	}
}

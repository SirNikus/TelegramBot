using Microsoft.EntityFrameworkCore;
using PorusTestBot.Models;

namespace PorusTestBot
{
	class BotContext : DbContext
	{	
		public DbSet<User> User { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(
			@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=S:\repos\PorusTestBot\PorusTestBot\DataBase\Database1.mdf;Integrated Security=True");
	}
}

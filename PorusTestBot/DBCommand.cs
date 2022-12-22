using PorusTestBot.Models;

namespace PorusTestBot
{
	public class DBCommand
	{
		BotContext context = new();

		public async Task AddNewUserAsync(long userId, string firstName, string lastName)
		{
			await context.User.AddAsync(new User
			{
				UserId = userId,
				FirstName = firstName,
				LastName = lastName
			});
			await context.SaveChangesAsync();
		}

		
	}
}

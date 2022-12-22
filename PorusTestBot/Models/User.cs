using System.ComponentModel.DataAnnotations;

namespace PorusTestBot.Models
{
	public partial class User
	{
		[Key]
		public long UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}

using Quorum.Shared.Interfaces;

namespace Quorum.Entities.Domain
{
	public class User : IEntity
	{
		public int Id { get; set; }

		public string Email    { get; set; }
		public string Password { get; set; }

		public string Role { get; set; }
	}
}
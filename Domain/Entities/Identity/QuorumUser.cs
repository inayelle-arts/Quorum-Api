using Quorum.Shared.Interfaces;

namespace Quorum.Domain.Entities.Identity
{
	public class QuorumUser : IEntity
	{
		public int Id { get; set; }

		public string Email        { get; set; }
		public string Role         { get; set; }
		public string PasswordHash { get; set; }
	}
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Quorum.Shared.Interfaces;

namespace Quorum.Domain.Entities.Identity
{
	public class QuorumUser : IEntity
	{
		public int Id       { get; set; }
		public int DomainId { get; set; }

		[Required]
		[MaxLength(255)]
		public string Email { get; set; }

		[Required]
		public string PasswordHash { get; set; }

		[ForeignKey(nameof(QuorumRole))]
		public int RoleId { get; set; }

		public QuorumRole Role { get; set; }
	}
}
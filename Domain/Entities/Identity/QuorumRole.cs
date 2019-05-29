using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.Domain.Entities.Identity
{
	public sealed class QuorumRole : IEntity
	{
		public int Id { get; set; }

		[MaxLength(255)]
		public string Name { get; set; }
	}
}
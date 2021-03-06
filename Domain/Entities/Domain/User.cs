using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.Domain.Entities.Domain
{
	public class User : IEntity
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(255)]
		public string Email { get; set; }
	}
}
using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.Domain.Entities.Domain
{
	public class ChallengedAnswer : IEntity
	{
		public int Id { get; set; }

		public int    SourceAnswerId { get; set; }
		public Answer SourceAnswer   { get; set; }

		public int                ChallengedQuestionId { get; set; }
		public ChallengedQuestion ChallengedQuestion   { get; set; }

		[Required]
		public bool IsUserCorrect { get; set; }
	}
}
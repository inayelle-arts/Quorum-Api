using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Entities
{
	public class ChallengedAnswer : IEntity
	{
		public int Id { get; set; }

		public int    SourceAnswerId { get; set; }
		public Answer SourceAnswer   { get; set; }

		public bool IsUserCorrect { get; set; }
	}
}
using Quorum.Shared.Interfaces;

namespace Quorum.Entities.Domain
{
	public class Tag : IEntity
	{
		public int    Id      { get; set; }
		public string Content { get; set; }

		public int TestId { get; set; }
		public Test Test { get; set; }
	}
}
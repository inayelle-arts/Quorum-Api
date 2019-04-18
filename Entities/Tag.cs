using Quorum.Shared.Interfaces;

namespace Quorum.Entities
{
	public class Tag : IEntity
	{
		public int    Id      { get; set; }
		public string Content { get; set; }
	}
}
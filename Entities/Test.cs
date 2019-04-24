using System.Collections.Generic;

using Quorum.Shared.Interfaces;

namespace Quorum.Entities
{
	public class Test : IEntity
	{
		public int Id { get; set; }

		public string Name      { get; set; }
		public string Description { get; set; }

		public ICollection<Tag>      Tags      { get; set; }
		public ICollection<Question> Questions { get; set; }

		public Test()
		{
			Tags      = new List<Tag>();
			Questions = new List<Question>();
		}
	}
}
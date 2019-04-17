using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Entities
{
	public class ChallengedTest : IEntity
	{
		public int Id { get; set; }

		public int TimeSpent { get; set; }

		public int  SourceTestId { get; set; }
		public Test SourceTest   { get; set; }

		public int MaximumScore { get; set; }
		public int UserScore    { get; set; }

		//TODO: passed by whom?

		public ICollection<ChallengedQuestion> Questions { get; set; }

		public ChallengedTest()
		{
			Questions = new List<ChallengedQuestion>();
		}
	}
}
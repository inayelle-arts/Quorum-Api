using System;
using System.Collections.Generic;
using Quorum.Shared.Interfaces;

namespace Quorum.Entities.Domain
{
	public class ChallengedTest : IEntity
	{
		public int Id { get; set; }

		public DateTime ChallengedAt { get; set; }

		public int MaximumScore { get; set; }
		public int UserScore    { get; set; }

		public int  SourceTestId { get; set; }
		public Test SourceTest   { get; set; }

		public int  UserId { get; set; }
		public User User   { get; set; }

		public ICollection<ChallengedQuestion> Questions { get; set; }

		public ChallengedTest()
		{
			Questions = new List<ChallengedQuestion>();
		}
	}
}
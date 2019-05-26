using System.Collections.Generic;
using Quorum.Shared.Interfaces;

namespace Quorum.Domain.Entities.Domain
{
	public class ChallengedQuestion : IEntity
	{
		public int Id { get; set; }

		public int      SourceQuestionId { get; set; }
		public Question SourceQuestion   { get; set; }

		public int TotalScore { get; set; }
		public int UserScore  { get; set; }

		public ICollection<ChallengedAnswer> Answers { get; set; }

		public int 			  ChallengedTestId { get; set; }
		public ChallengedTest ChallengedTest   { get; set; }

		public ChallengedQuestion()
		{
			Answers = new List<ChallengedAnswer>();
		}
	}
}
using System.Collections.Generic;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Challenge.ResultsModels
{
	public sealed class ChallengeQuestionResultModel : IDataTransferObject
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public ICollection<ChallengeAnswerResultModel> Answers { get; set; }
	}
}
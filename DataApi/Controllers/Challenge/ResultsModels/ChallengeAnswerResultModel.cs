using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Challenge.ResultsModels
{
	public sealed class ChallengeAnswerResultModel : IDataTransferObject
	{
		public int Id { get; set; }

		public string Content { get; set; }
	}
}
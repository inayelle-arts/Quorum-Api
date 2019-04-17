using Quorum.Shared.Interfaces;

namespace Quorum.Api.Controllers.Challenge.ResultsModels
{
	public sealed class ChallengeAnswerResultModel : IDataTransferObject
	{
		public int Id { get; set; }

		public string Content { get; set; }
	}
}
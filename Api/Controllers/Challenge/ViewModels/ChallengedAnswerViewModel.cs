using Quorum.Shared.Interfaces;

namespace Quorum.Api.Controllers.Challenge.ViewModels
{
	public sealed class ChallengedAnswerViewModel : IDataTransferObject
	{
		public int SourceAnswerId { get; set; }

		public bool IsCorrect { get; set; }
	}
}
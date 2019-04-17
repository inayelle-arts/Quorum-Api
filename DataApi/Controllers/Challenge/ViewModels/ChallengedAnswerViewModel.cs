using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Challenge.ViewModels
{
	public sealed class ChallengedAnswerViewModel : IDataTransferObject
	{
		public int SourceAnswerId { get; set; }

		public bool IsCorrect { get; set; }
	}
}
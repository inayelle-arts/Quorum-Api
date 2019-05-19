using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Challenge.ViewModels
{
	public sealed class ChallengedAnswerViewModel : IDataTransferObject
	{
		[Required]
		public int SourceAnswerId { get; set; }

		[Required]
		public bool IsCorrect { get; set; }
	}
}
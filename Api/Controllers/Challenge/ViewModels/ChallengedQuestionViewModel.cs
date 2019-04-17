using System.Collections.Generic;
using Quorum.Shared.Interfaces;

namespace Quorum.Api.Controllers.Challenge.ViewModels
{
	public sealed class ChallengedQuestionViewModel : IDataTransferObject
	{
		public int SourceQuestionId { get; set; }

		public ICollection<ChallengedAnswerViewModel> Answers { get; set; }

		public ChallengedQuestionViewModel()
		{
			Answers = new List<ChallengedAnswerViewModel>();
		}
	}
}
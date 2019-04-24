using System.Collections.Generic;

using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Challenge.ViewModels
{
	public sealed class ChallengedTestViewModel : IDataTransferObject
	{
		public int SourceTestId { get; set; }

		//TODO: passed by whom?

		public ICollection<ChallengedQuestionViewModel> Questions { get; set; }

		public ChallengedTestViewModel()
		{
			Questions = new List<ChallengedQuestionViewModel>();
		}
	}
}
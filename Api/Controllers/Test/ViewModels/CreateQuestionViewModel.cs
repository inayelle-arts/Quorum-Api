using System.Collections.Generic;
using Quorum.Shared.Interfaces;

namespace Quorum.Api.Controllers.Test.ViewModels
{
	public sealed class CreateQuestionViewModel: IDataTransferObject
	{
		public string Content { get; set; }

		public ICollection<CreateAnswerViewModel> Answers { get; set; }

		public CreateQuestionViewModel()
		{
			Answers = new List<CreateAnswerViewModel>();
		}
	}
}
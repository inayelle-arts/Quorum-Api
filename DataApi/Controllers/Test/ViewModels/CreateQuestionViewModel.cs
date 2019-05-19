using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Test.ViewModels
{
	public sealed class CreateQuestionViewModel: IDataTransferObject
	{
		[Required]
		public string Content { get; set; }

		[Required]
		public ICollection<CreateAnswerViewModel> Answers { get; set; }
	}
}
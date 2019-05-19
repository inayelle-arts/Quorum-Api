using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Test.ViewModels
{
	public sealed class CreateAnswerViewModel : IDataTransferObject
	{
		[Required]
		public string Content { get; set; }

		[Required]
		public bool IsCorrect { get; set; }
	}
}
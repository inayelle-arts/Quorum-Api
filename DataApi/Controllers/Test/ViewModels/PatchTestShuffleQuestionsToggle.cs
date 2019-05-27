using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Test.ViewModels
{
	public sealed class PatchTestShuffleQuestionsToggle : IDataTransferObject
	{
		[Required]
		public bool ShuffleQuestions { get; set; }
	}
}
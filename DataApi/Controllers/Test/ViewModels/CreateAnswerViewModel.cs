using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Test.ViewModels
{
	public sealed class CreateAnswerViewModel : IDataTransferObject
	{
		public string Content   { get; set; }
		public bool   IsCorrect { get; set; }
	}
}
using Quorum.Shared.Interfaces;

namespace Quorum.Api.Controllers.Test.ViewModels
{
	public sealed class CreateAnswerViewModel : IDataTransferObject
	{
		public string Content   { get; set; }
		public bool   IsCorrect { get; set; }
	}
}
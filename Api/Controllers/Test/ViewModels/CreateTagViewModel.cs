using Quorum.Shared.Interfaces;

namespace Quorum.Api.Controllers.Test.ViewModels
{
	public sealed class CreateTagViewModel : IDataTransferObject
	{
		public string Content { get; set; }
	}
}
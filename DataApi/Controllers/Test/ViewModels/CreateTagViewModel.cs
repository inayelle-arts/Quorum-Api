using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Test.ViewModels
{
	public sealed class CreateTagViewModel : IDataTransferObject
	{
		public string Content { get; set; }
	}
}
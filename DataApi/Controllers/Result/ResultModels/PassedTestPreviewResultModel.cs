using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Result.ResultModels
{
	public sealed class PassedTestPreviewResultModel : IDataTransferObject
	{
		public int    Id        { get; set; }
		public string Name      { get; set; }
		public string Date      { get; set; }
		public string UserEmail { get; set; }
	}
}
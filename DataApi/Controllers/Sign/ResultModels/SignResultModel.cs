using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Sign.ResultModels
{
	public sealed class SignResultModel : IDataTransferObject
	{
		public string Token { get; set; }

		public SignResultModel(string token)
		{
			Token = token;
		}
	}
}
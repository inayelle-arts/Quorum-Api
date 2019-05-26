using Quorum.Shared.Interfaces;

namespace Quorum.IdentityApi.Controllers.Token.ResultModels
{
	public sealed class SignInResultModel : IDataTransferObject
	{
		public string Token { get; set; }
	}
}
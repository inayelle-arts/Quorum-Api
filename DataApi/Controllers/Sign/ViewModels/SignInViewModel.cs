using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Sign.ViewModels
{
	public sealed class SignInViewModel : IDataTransferObject
	{
		public string Email    { get; set; }
		public string Password { get; set; }
	}
}
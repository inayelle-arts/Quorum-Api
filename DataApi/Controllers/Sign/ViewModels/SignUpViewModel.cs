using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Sign.ViewModels
{
	public sealed class SignUpViewModel : IDataTransferObject
	{
		public string UserType { get; set; }
		public string Email    { get; set; }
		public string Password { get; set; }
	}
}
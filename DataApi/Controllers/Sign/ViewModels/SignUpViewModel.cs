using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Sign.ViewModels
{
	public sealed class SignUpViewModel : IDataTransferObject
	{
		[Required]
		public string UserType { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
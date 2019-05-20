using System.ComponentModel.DataAnnotations;
using Quorum.DataApi.Validators;
using Quorum.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Sign.ViewModels
{
	public sealed class SignUpViewModel : IDataTransferObject
	{
		[Required]
		[StringRange(UserRole.Tutor, UserRole.Student)]
		public string Role { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MinLength(8)]
		public string Password { get; set; }
	}
}
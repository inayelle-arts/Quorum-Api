using System.ComponentModel.DataAnnotations;
using MediatR;
using Quorum.Domain.Entities.Identity;

namespace Quorum.Domain.IdentityCore.Infrastructure.Commands.SignIn
{
	public sealed class SignInRequest : IRequest<QuorumUser>
	{
		[Required]
		[EmailAddress]
		public string Email { get; }

		[Required]
		public string Password { get; }

		public SignInRequest(string email, string password)
		{
			Email    = email;
			Password = password;
		}
	}
}
using MediatR;
using Quorum.Domain.Entities.Identity;

namespace Quorum.Domain.IdentityCore.Infrastructure.Commands.SignUp
{
	public sealed class SignUpRequest : IRequest<QuorumUser>
	{
		public int    DomainId { get; }
		public string Email    { get; }
		public string Password { get; }
		public string Role     { get; }

		public SignUpRequest(int domainId, string email, string password, string role)
		{
			DomainId = domainId;
			Email    = email;
			Password = password;
			Role     = role;
		}
	}
}
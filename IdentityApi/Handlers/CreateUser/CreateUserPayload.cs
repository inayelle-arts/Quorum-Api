namespace Quorum.IdentityApi.Handlers.CreateUser
{
	internal sealed class CreateUserPayload
	{
		public string Email    { get; set; }
		public string Password { get; set; }
		public string Role     { get; set; }
	}
}
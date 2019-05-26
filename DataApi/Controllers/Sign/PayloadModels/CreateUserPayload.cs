namespace Quorum.DataApi.Controllers.Sign.PayloadModels
{
	public sealed class CreateUserPayload
	{
		public int    DomainId { get; set; }
		public string Email    { get; set; }
		public string Role     { get; set; }
		public string Password { get; set; }
	}
}
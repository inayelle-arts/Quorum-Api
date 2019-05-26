namespace Quorum.Domain.IdentityCore.Services.JwtAuthentication
{
	public sealed class JwtSettings
	{
		public string Audience { get; set; }
		public string Issuer   { get; set; }
		public string SignKey  { get; set; }

		public string HashingAlgorithm { get; set; }

		public int TokenLifetime { get; set; }
	}
}
using Microsoft.EntityFrameworkCore;
using Quorum.Domain.Entities.Identity;

namespace Quorum.DataProviders.IdentityDataProvider
{
	public sealed class IdentityDataContext : DbContext
	{
		public DbSet<QuorumUser> QuorumUsers { get; set; }

		public IdentityDataContext(DbContextOptions options) : base(options)
		{
		}
	}
}
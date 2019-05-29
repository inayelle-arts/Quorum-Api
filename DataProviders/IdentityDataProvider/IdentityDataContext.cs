using Microsoft.EntityFrameworkCore;
using Quorum.Domain.Entities.Enums;
using Quorum.Domain.Entities.Identity;

namespace Quorum.DataProviders.IdentityDataProvider
{
	public sealed class IdentityDataContext : DbContext
	{
		public DbSet<QuorumUser> QuorumUsers { get; set; }
		public DbSet<QuorumRole> QuorumRoles { get; set; }

		public IdentityDataContext(DbContextOptions options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<QuorumRole>()
						.HasData(new QuorumRole
								 {
									 Id   = 1,
									 Name = UserRole.Tutor
								 },
								 new QuorumRole
								 {
									 Id   = 2,
									 Name = UserRole.Student
								 });
		}
	}
}
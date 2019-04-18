using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quorum.Entities;

namespace Quorum.DataAccess.IdentityDataProvider
{
	public sealed class IdentityDataContext : IdentityDbContext<User>
	{
		public IdentityDataContext(DbContextOptions options) : base(options)
		{
		}
	}
}
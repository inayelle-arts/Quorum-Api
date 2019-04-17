using Microsoft.EntityFrameworkCore;
using Quorum.BusinessCore.Entities;

namespace Quorum.DataAccess.Ef
{
	public class EfDataAccessContext : DbContext
	{
		public DbSet<Test>     Tests     { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer>   Answers   { get; set; }

		public DbSet<ChallengedTest>     PassedTests     { get; set; }
		public DbSet<ChallengedQuestion> PassedQuestions { get; set; }
		public DbSet<ChallengedAnswer>   PassedAnswers   { get; set; }

		public EfDataAccessContext(DbContextOptions options) : base(options)
		{
		}
	}
}
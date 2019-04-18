using Microsoft.EntityFrameworkCore;
using Quorum.Entities;

namespace Quorum.DataAccess.EfDataProvider
{
	public class EfDataContext : DbContext
	{
		public DbSet<Test>     Tests     { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer>   Answers   { get; set; }

		public DbSet<ChallengedTest>     PassedTests     { get; set; }
		public DbSet<ChallengedQuestion> PassedQuestions { get; set; }
		public DbSet<ChallengedAnswer>   PassedAnswers   { get; set; }

		public EfDataContext(DbContextOptions options) : base(options)
		{
		}
	}
}
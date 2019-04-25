using Microsoft.EntityFrameworkCore;

using Quorum.Entities;

namespace Quorum.DataAccess.EfDataProvider
{
	public class EfDataContext : DbContext
	{
		public DbSet<Test>     Tests     { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer>   Answers   { get; set; }
		public DbSet<Tag>	   Tags      { get; set; }

		public DbSet<ChallengedTest>     ChallengedTests     { get; set; }
		public DbSet<ChallengedQuestion> ChallengedQuestions { get; set; }
		public DbSet<ChallengedAnswer>   ChallengedAnswers   { get; set; }

		public EfDataContext(DbContextOptions options) : base(options)
		{
		}
	}
}
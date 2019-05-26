using System.Data.Common;
using Microsoft.Extensions.DependencyInjection;

using Quorum.BusinessCore.Interfaces;
using Quorum.DataProviders.AdoDataProvider.Details;
using Quorum.DataProviders.AdoDataProvider.Repositories;

using SqlKata.Compilers;
using SqlKata.Execution;

namespace Quorum.DataProviders.AdoDataProvider.Extensions
{
    public static class ServiceCollectionExtensions
    {
		public static void AddAdoDataAccess(this IServiceCollection services, string connectionString)
		{
			services.AddTransient<DbConnection>(s => ConnectionFactory.Create(connectionString));

			services.AddTransient<QueryFactory>(s =>
			{
				var sqlCompiler = new PostgresCompiler();
				var connection = s.GetService<DbConnection>();

				return new QueryFactory(connection, sqlCompiler);
			});

			services.AddRepositories();
		}

		private static void AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<ITestRepository, TestRepository>()
			        .AddTransient<ITagRepository, TagRepository>()
			        .AddTransient<IQuestionRepository, QuestionRepository>()
			        .AddTransient<IAnswerRepository, AnswerRepository>()
			        .AddTransient<IChallengedTestRepository, ChallengedTestRepository>()
			        .AddTransient<IChallengedQuestionRepository, ChallengedQuestionRepository>()
			        .AddTransient<IChallengedAnswerRepository, ChallengedAnswerRepository>()
			        .AddTransient<IUserRepository, UserRepository>();
		}
    }
}
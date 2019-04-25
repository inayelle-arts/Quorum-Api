using System;
using System.Data.Common;

using BusinessCore.Interfaces;

using Microsoft.Extensions.DependencyInjection;

using Quorum.BusinessCore.Interfaces;
using Quorum.DataAccess.AdoDataProvider.Details;
using Quorum.DataAccess.AdoDataProvider.Repositories;

using SqlKata.Compilers;
using SqlKata.Execution;

namespace Quorum.DataAccess.AdoDataProvider.Extensions
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
					.AddTransient<IChallengedAnswerRepository, ChallengedAnswerRepository>();
		}
    }
}
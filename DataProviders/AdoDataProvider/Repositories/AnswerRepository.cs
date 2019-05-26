using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quorum.BusinessCore.Interfaces;
using Quorum.DataProviders.AdoDataProvider.Base;
using Quorum.DataProviders.AdoDataProvider.Extensions;
using Quorum.Entities.Domain;
using SqlKata.Execution;

namespace Quorum.DataProviders.AdoDataProvider.Repositories
{
	public class AnswerRepository : AdoRepositoryBase<Answer>, IAnswerRepository
	{
		public AnswerRepository(QueryFactory queryFactory) : base(queryFactory)
		{
		}

		public override async Task<int> CreateAsync(Answer answer)
		{
			var id = await Query.InsertReturningIdAsync<int>(new
			{
				answer.Content,
				answer.IsCorrect,
				answer.QuestionId
			});

			answer.Id = id;

			return id;
		}

		public async Task<ICollection<Answer>> GetByParentQuestionAsync(Question question)
		{
			var answers = await Query.Where("QuestionId", question.Id).GetAsync<Answer>();

			foreach (var answer in answers)
			{
				answer.Question = question;
			}

			return answers.ToList();
		}
	}
}
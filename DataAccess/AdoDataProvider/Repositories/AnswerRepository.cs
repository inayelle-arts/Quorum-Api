using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quorum.BusinessCore.Interfaces;
using Quorum.DataAccess.AdoDataProvider.Base;
using Quorum.DataAccess.AdoDataProvider.Extensions;
using Quorum.Entities;

using SqlKata;
using SqlKata.Execution;

namespace Quorum.DataAccess.AdoDataProvider.Repositories
{
	public class AnswerRepository : AdoRepositoryBase<Answer>, IAnswerRepository
	{
		public AnswerRepository(QueryFactory queryFactory) : base(queryFactory)
		{
		}

		public override async Task<int> Create(Answer answer)
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
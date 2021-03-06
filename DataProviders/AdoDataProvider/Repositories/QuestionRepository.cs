using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quorum.BusinessCore.Interfaces;
using Quorum.BusinessCore.Interfaces.Repositories;
using Quorum.DataProviders.AdoDataProvider.Base;
using Quorum.DataProviders.AdoDataProvider.Extensions;
using Quorum.Domain.Entities.Domain;
using SqlKata.Execution;

namespace Quorum.DataProviders.AdoDataProvider.Repositories
{
	public class QuestionRepository : AdoRepositoryBase<Question>, IQuestionRepository
	{
		private readonly IAnswerRepository _answerRepository;

		public QuestionRepository(QueryFactory queryFactory, IAnswerRepository answerRepository) : base(queryFactory) =>
				_answerRepository = answerRepository;

		public override async Task<int> CreateAsync(Question question)
		{
			int id = await Query.InsertReturningIdAsync<int>(new
			{
				question.Content,
				question.TestId
			});

			question.Id = id;

			foreach (var answer in question.Answers)
			{
				answer.QuestionId = question.Id;
			}

			await _answerRepository.CreateAsync(question.Answers);

			return id;
		}

		public async Task<ICollection<Question>> GetByParentTestAsync(Test parent)
		{
			var questions = await Query.Where("TestId", parent.Id).GetAsync<Question>();

			foreach (var question in questions)
			{
				question.Test    = parent;
				question.Answers = await _answerRepository.GetByParentQuestionAsync(question);
			}

			return questions.ToList();
		}
	}
}
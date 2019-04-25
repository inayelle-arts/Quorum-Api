using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quorum.BusinessCore.Interfaces;
using Quorum.DataAccess.AdoDataProvider.Base;
using Quorum.DataAccess.AdoDataProvider.Extensions;
using Quorum.Entities;

using SqlKata.Execution;

namespace Quorum.DataAccess.AdoDataProvider.Repositories
{
	public class QuestionRepository : AdoRepositoryBase<Question>, IQuestionRepository
	{
		private readonly IAnswerRepository _answerRepository;

		public QuestionRepository(QueryFactory queryFactory, IAnswerRepository answerRepository) : base(queryFactory)
		{
			_answerRepository = answerRepository;
		}

		public override async Task<int> Create(Question question)
		{
			var id = await Query.InsertReturningIdAsync<int>(new
			{
				question.Content,
				question.TestId
			});

			question.Id = id;

			foreach (var answer in question.Answers)
			{
				answer.QuestionId = question.Id;
			}

			await _answerRepository.Create(question.Answers);

			return id;
		}

		public async Task<ICollection<Question>> GetByParentTestAsync(Test parent)
		{
			var questions = await Query.Where("TestId", parent.Id).GetAsync<Question>();

			foreach (var question in questions)
			{
				question.Test = parent;
				question.Answers = await _answerRepository.GetByParentQuestionAsync(question);
			}

			return questions.ToList();
		}
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quorum.BusinessCore.Interfaces;
using Quorum.DataProviders.AdoDataProvider.Base;
using Quorum.DataProviders.AdoDataProvider.Extensions;
using Quorum.Entities;
using Quorum.Entities.Domain;
using SqlKata.Execution;

namespace Quorum.DataProviders.AdoDataProvider.Repositories
{
	public class ChallengedQuestionRepository : AdoRepositoryBase<ChallengedQuestion>, IChallengedQuestionRepository
	{
		private readonly IQuestionRepository _questionRepository;
		private readonly IChallengedAnswerRepository _answerRepository;

		public ChallengedQuestionRepository(QueryFactory queryFactory,
											IQuestionRepository questionRepository,
											IChallengedAnswerRepository answerRepository) : base(queryFactory)
		{
			_questionRepository = questionRepository;
			_answerRepository = answerRepository;
		}

		public async override Task<int> CreateAsync(ChallengedQuestion question)
		{
			var id = await Query.InsertReturningIdAsync<int>(new
			{
				question.ChallengedTestId,
				question.SourceQuestionId,
				question.TotalScore,
				question.UserScore
			});

			question.Id = id;

			foreach (var answer in question.Answers)
			{
				answer.ChallengedQuestionId = question.Id;
				answer.ChallengedQuestion = question;
			}

			await _answerRepository.CreateAsync(question.Answers);

			return id;
		}

		public async Task<ICollection<ChallengedQuestion>> GetByParentTestAsync(ChallengedTest test)
		{
			var questions = await Query.Where("ChallengedTestId", test.Id).GetAsync<ChallengedQuestion>();

			foreach (var question in questions)
			{
				question.ChallengedTest = test;
				question.SourceQuestion = await _questionRepository.GetByIdAsync(question.SourceQuestionId);
				question.Answers = await _answerRepository.GetByParentQuestionAsync(question);
			}

			return questions.ToList();
		}
	}
}
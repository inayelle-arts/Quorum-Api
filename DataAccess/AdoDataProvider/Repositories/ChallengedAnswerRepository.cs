using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Quorum.BusinessCore.Interfaces;
using Quorum.DataAccess.AdoDataProvider.Base;
using Quorum.DataAccess.AdoDataProvider.Extensions;
using Quorum.DataAccess.AdoDataProvider.Repositories;
using Quorum.Entities;
using Quorum.Entities.Domain;
using SqlKata.Execution;

namespace Quorum.DataAccess.AdoDataProvider.Repositories
{
	public class ChallengedAnswerRepository : AdoRepositoryBase<ChallengedAnswer>, IChallengedAnswerRepository
	{
		private readonly IAnswerRepository _answerRepository;

		public ChallengedAnswerRepository(QueryFactory queryFactory,
										  IAnswerRepository answerRepository) : base(queryFactory)
		{
			_answerRepository = answerRepository;
		}

		public override async Task<int> CreateAsync(ChallengedAnswer answer)
		{
			var id = await Query.InsertReturningIdAsync<int>(new
			{
				answer.IsUserCorrect,
				answer.SourceAnswerId,
				answer.ChallengedQuestionId
			});

			answer.Id = id;

			answer.SourceAnswer = await _answerRepository.GetByIdAsync(answer.SourceAnswerId);

			return id;
		}

		public async Task<ICollection<ChallengedAnswer>> GetByParentQuestionAsync(ChallengedQuestion question)
		{
			var answers = await Query.Where("ChallengedQuestionId", question.Id).GetAsync<ChallengedAnswer>();

			foreach (var answer in answers)
			{
				answer.ChallengedQuestion = question;
				answer.SourceAnswer = await _answerRepository.GetByIdAsync(answer.SourceAnswerId);
			}

			return answers.ToList();
		}
	}
}
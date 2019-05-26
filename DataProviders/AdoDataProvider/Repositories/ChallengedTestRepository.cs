using System.Collections.Generic;
using System.Threading.Tasks;
using Quorum.BusinessCore.Interfaces;
using Quorum.DataProviders.AdoDataProvider.Base;
using Quorum.DataProviders.AdoDataProvider.Extensions;
using Quorum.Entities;
using Quorum.Entities.Domain;
using SqlKata.Execution;

namespace Quorum.DataProviders.AdoDataProvider.Repositories
{
	public class ChallengedTestRepository : AdoRepositoryBase<ChallengedTest>, IChallengedTestRepository
	{
		private readonly IChallengedQuestionRepository _questionRepository;
		private readonly ITestRepository               _testRepository;
		private readonly IUserRepository               _userRepository;

		public ChallengedTestRepository(QueryFactory                  queryFactory,
		                                IChallengedQuestionRepository questionRepository,
		                                ITestRepository               testRepository,
		                                IUserRepository               userRepository) : base(queryFactory)
		{
			_questionRepository = questionRepository;
			_testRepository     = testRepository;
			_userRepository     = userRepository;
		}

		public override async Task<int> CreateAsync(ChallengedTest test)
		{
			var id = await Query.InsertReturningIdAsync<int>(new
			{
					test.SourceTestId,
					test.UserScore,
					test.MaximumScore
			});

			test.Id         = id;
			test.SourceTest = await _testRepository.GetByIdAsync(test.SourceTestId);

			foreach (var question in test.Questions)
			{
				question.ChallengedTestId = test.Id;
				question.ChallengedTest   = test;
			}

			await _questionRepository.CreateAsync(test.Questions);

			return id;
		}

		public Task<IEnumerable<ChallengedTest>> GetStudentsResultsAsync(int userId)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<ChallengedTest>> GetTutorsResultsAsync(int userId)
		{
			throw new System.NotImplementedException();
		}

		public override async Task<ChallengedTest> GetByIdAsync(int id)
		{
			var test = await base.GetByIdAsync(id);

			if (test == null)
			{
				return null;
			}

			test.Questions  = await _questionRepository.GetByParentTestAsync(test);
			test.User       = await _userRepository.GetByIdAsync(test.UserId);
			test.SourceTest = await _testRepository.GetByIdAsync(test.SourceTestId);

			return test;
		}
	}
}
using System.Threading.Tasks;

using Quorum.BusinessCore.Interfaces;
using Quorum.DataAccess.AdoDataProvider.Base;
using Quorum.DataAccess.AdoDataProvider.Extensions;
using Quorum.Entities;

using SqlKata.Execution;

namespace Quorum.DataAccess.AdoDataProvider.Repositories
{
	public class ChallengedTestRepository : AdoRepositoryBase<ChallengedTest>, IChallengedTestRepository
	{
		private readonly IChallengedQuestionRepository _questionRepository;
		private readonly ITestRepository _testRepository;

		public ChallengedTestRepository(QueryFactory queryFactory,
										IChallengedQuestionRepository questionRepository,
										ITestRepository testRepository) : base(queryFactory)
		{
			_questionRepository = questionRepository;
			_testRepository = testRepository;
		}

		public override async Task<int> Create(ChallengedTest test)
		{
			var id = await Query.InsertReturningIdAsync<int>(new
			{
				test.SourceTestId,
				test.UserScore,
				test.MaximumScore
			});

			test.Id = id;
			test.SourceTest = await _testRepository.GetByIdAsync(test.SourceTestId);

			foreach (var question in test.Questions)
			{
				question.ChallengedTestId = test.Id;
				question.ChallengedTest = test;
			}

			await _questionRepository.Create(test.Questions);

			return id;
		}

		public override async Task<ChallengedTest> GetByIdAsync(int id)
		{
			var test = await base.GetByIdAsync(id);

			if (test == null)
			{
				return null;
			}

			test.Questions = await _questionRepository.GetByParentTestAsync(test);

			test.SourceTest = await _testRepository.GetByIdAsync(test.SourceTestId);

			return test;
		}
	}
}
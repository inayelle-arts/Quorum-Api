using System;
using System.Linq;
using System.Threading.Tasks;
using Quorum.BusinessCore.Interfaces.Repositories;
using Quorum.BusinessCore.Interfaces.Services;
using Quorum.Domain.Entities.Domain;

namespace Quorum.BusinessCore.Services.Challenge
{
	public sealed class ChallengeService : IChallengeService
	{
		private readonly ITestRepository           _tests;
		private readonly IChallengedTestRepository _challengedTests;

		public ChallengeService(ITestRepository tests, IChallengedTestRepository challengedTests)
		{
			_tests           = tests;
			_challengedTests = challengedTests;
		}

		public async Task<Test> GetTestForChallengeAsync(int id)
		{
			var test = await _tests.GetByIdAsync(id);

			if (test == null)
			{
				return null;
			}

			if (test.ShuffleQuestionsOnChallenge)
			{
				ShuffleQuestions(test);
			}

			return test;
		}
		
		public async Task<int> PerformChallengeAsync(ChallengedTest test)
		{
			var challengeExecutor = new ChallengeExecutor();

			test.SourceTest = await _tests.GetByIdAsync(test.SourceTestId);

			await challengeExecutor.ChallengeAsync(test);

			return await _challengedTests.CreateAsync(test);
		}

		private void ShuffleQuestions(Test test)
		{
			var random = new Random();
			
			test.Questions = test.Questions.OrderBy(q => random.Next()).ToList();
		}
	}
}
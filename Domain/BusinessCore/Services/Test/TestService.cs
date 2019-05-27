using System.Collections.Generic;
using System.Threading.Tasks;
using Quorum.BusinessCore.Interfaces.Repositories;
using Quorum.BusinessCore.Interfaces.Services;

namespace Quorum.BusinessCore.Services.Test
{
	internal sealed class TestService : ITestService
	{
		private readonly ITestRepository _testRepository;

		public TestService(ITestRepository testRepository)
		{
			_testRepository = testRepository;
		}

		public async Task<Domain.Entities.Domain.Test> CreateTestAsync(Domain.Entities.Domain.Test test)
		{
			await _testRepository.CreateAsync(test);

			return test;
		}

		public async Task<ICollection<Domain.Entities.Domain.Test>> GetTutorOwnTestsAsync(int tutorId)
		{
			return await _testRepository.GetTutorOwnTestsAsync(tutorId);
		}

		public async Task<Domain.Entities.Domain.Test> DeleteTestAsync(int testId)
		{
			var test = await _testRepository.GetByIdAsync(testId);

			if (test == null)
			{
				return null;
			}

			await _testRepository.DeleteAsync(test);

			return test;
		}

		public async Task<Domain.Entities.Domain.Test> ToggleTestShuffleQuestionsAsync(int testId, bool toggleState)
		{
			var test = await _testRepository.GetByIdAsync(testId);

			if (test == null)
			{
				return null;
			}

			test.ShuffleQuestionsOnChallenge = toggleState;

			await _testRepository.UpdateAsync(test);

			return test;
		}
	}
}
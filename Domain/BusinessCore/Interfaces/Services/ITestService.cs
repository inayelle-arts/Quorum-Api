using System.Collections.Generic;
using System.Threading.Tasks;
using Quorum.Domain.Entities.Domain;

namespace Quorum.BusinessCore.Interfaces.Services
{
	public interface ITestService
	{
		Task<Test> CreateTestAsync(Test test);

		Task<ICollection<Test>> GetTutorOwnTestsAsync(int tutorId);

		Task<Test> DeleteTestAsync(int testId);

		Task<Test> ToggleTestShuffleQuestionsAsync(int testId, bool toggleState);
	}
}
using System.Threading.Tasks;
using Quorum.Domain.Entities.Domain;

namespace Quorum.BusinessCore.Interfaces.Services
{
	public interface IChallengeService
	{
		Task<Test> GetTestForChallengeAsync(int id);
		
		Task<int> PerformChallengeAsync(ChallengedTest test);
	}
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Quorum.Domain.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces.Repositories
{
	public interface IChallengedTestRepository : IRepository<ChallengedTest>
	{
		Task<IEnumerable<ChallengedTest>> GetStudentsResultsAsync(int userId);
		
		Task<IEnumerable<ChallengedTest>> GetTutorsResultsAsync(int userId);
	}
}
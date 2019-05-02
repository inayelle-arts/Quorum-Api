using System.Collections.Generic;
using System.Threading.Tasks;
using Quorum.Entities;
using Quorum.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces
{
	public interface IChallengedTestRepository : IRepository<ChallengedTest>
	{
		Task<IEnumerable<ChallengedTest>> GetStudentsResultsAsync(int userId);
		
		Task<IEnumerable<ChallengedTest>> GetTutorsResultsAsync(int userId);
	}
}
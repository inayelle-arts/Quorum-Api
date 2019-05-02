using System.Collections.Generic;
using System.Threading.Tasks;
using Quorum.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces
{
	public interface ITestRepository : IRepository<Test>
	{
		Task<IEnumerable<Test>> GetOwnTestsAsync(int userId);
	}
}
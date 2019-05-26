using System.Collections.Generic;
using System.Threading.Tasks;
using Quorum.Domain.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces.Repositories
{
	public interface IChallengedQuestionRepository : IRepository<ChallengedQuestion>
	{
		Task<ICollection<ChallengedQuestion>> GetByParentTestAsync(ChallengedTest test);
	}
}
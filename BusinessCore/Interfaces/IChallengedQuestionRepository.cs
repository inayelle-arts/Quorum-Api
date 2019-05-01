using System.Collections.Generic;
using System.Threading.Tasks;

using Quorum.Entities;
using Quorum.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces
{
	public interface IChallengedQuestionRepository : IRepository<ChallengedQuestion>
	{
		Task<ICollection<ChallengedQuestion>> GetByParentTestAsync(ChallengedTest test);
	}
}
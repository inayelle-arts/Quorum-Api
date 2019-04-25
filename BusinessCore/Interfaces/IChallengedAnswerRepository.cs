using System.Collections.Generic;
using System.Threading.Tasks;

using Quorum.Entities;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces
{
	public interface IChallengedAnswerRepository : IRepository<ChallengedAnswer>
	{
		Task<ICollection<ChallengedAnswer>> GetByParentQuestionAsync(ChallengedQuestion question);
	}
}
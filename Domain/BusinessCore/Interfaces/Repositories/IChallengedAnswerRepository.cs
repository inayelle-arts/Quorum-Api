using System.Collections.Generic;
using System.Threading.Tasks;
using Quorum.Domain.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces.Repositories
{
	public interface IChallengedAnswerRepository : IRepository<ChallengedAnswer>
	{
		Task<ICollection<ChallengedAnswer>> GetByParentQuestionAsync(ChallengedQuestion question);
	}
}
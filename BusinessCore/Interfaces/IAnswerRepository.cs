using System.Collections.Generic;
using System.Threading.Tasks;

using Quorum.Entities;
using Quorum.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces
{
	public interface IAnswerRepository : IRepository<Answer>
	{
		Task<ICollection<Answer>> GetByParentQuestionAsync(Question question);
	}
}
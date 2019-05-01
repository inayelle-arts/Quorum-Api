using System.Collections.Generic;
using System.Threading.Tasks;

using Quorum.Entities;
using Quorum.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces
{
	public interface IQuestionRepository : IRepository<Question>
	{
		Task<ICollection<Question>> GetByParentTestAsync(Test parent);
	}
}
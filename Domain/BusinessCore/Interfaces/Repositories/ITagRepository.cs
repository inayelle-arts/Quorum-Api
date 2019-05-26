using System.Collections.Generic;
using System.Threading.Tasks;
using Quorum.Domain.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
		Task<ICollection<Tag>> GetByParentTestAsync(Test parent);
    }
}
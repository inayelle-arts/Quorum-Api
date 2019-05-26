using System.Collections.Generic;
using System.Threading.Tasks;
using Quorum.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
		Task<ICollection<Tag>> GetByParentTestAsync(Test parent);
    }
}
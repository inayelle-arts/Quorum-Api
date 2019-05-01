using System.Collections.Generic;
using System.Threading.Tasks;

using Quorum.Entities;
using Quorum.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace BusinessCore.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
		Task<ICollection<Tag>> GetByParentTestAsync(Test parent);
    }
}
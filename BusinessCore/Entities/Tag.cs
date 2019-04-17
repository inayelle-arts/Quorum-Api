using System.ComponentModel.DataAnnotations.Schema;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Entities
{
	public class Tag : IEntity
	{
		public int    Id      { get; set; }
		public string Content { get; set; }
	}
}
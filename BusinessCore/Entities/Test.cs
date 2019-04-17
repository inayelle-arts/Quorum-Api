using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Quorum.Shared.Interfaces;

namespace Quorum.BusinessCore.Entities
{
	public class Test : IEntity
	{
		public int Id { get; set; }

		public string Name      { get; set; }
		public int    TimeLimit { get; set; }

		public ICollection<Tag>      Tags      { get; set; }
		public ICollection<Question> Questions { get; set; }

		public Test()
		{
			Tags      = new List<Tag>();
			Questions = new List<Question>();
		}
	}
}
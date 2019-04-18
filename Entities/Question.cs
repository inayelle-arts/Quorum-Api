using System.Collections.Generic;
using Quorum.Shared.Interfaces;

namespace Quorum.Entities
{
	public class Question : IEntity
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public ICollection<Answer> Answers { get; set; }

		public int  TestId { get; set; }
		public Test Test   { get; set; }

		public Question()
		{
			Answers = new List<Answer>();
		}
	}
}
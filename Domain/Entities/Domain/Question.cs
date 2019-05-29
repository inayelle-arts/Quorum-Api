using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.Domain.Entities.Domain
{
	public class Question : IEntity
	{
		public int Id { get; set; }

		[Required]
		public string Content { get; set; }

		public int  TestId { get; set; }
		public Test Test   { get; set; }

		public ICollection<Answer> Answers { get; set; }
	}
}
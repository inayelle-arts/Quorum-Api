using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.Domain.Entities.Domain
{
	public class Test : IEntity
	{
		public int Id { get; set; }

		public bool ShuffleQuestionsOnChallenge { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		public string Description { get; set; }

		public int  UserId { get; set; }
		public User User   { get; set; }

		public DateTime CreatedAt { get; set; }

		public ICollection<Tag>      Tags      { get; set; }
		public ICollection<Question> Questions { get; set; }
	}
}
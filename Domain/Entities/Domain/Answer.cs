using Quorum.Shared.Interfaces;

namespace Quorum.Domain.Entities.Domain
{
	public class Answer : IEntity
	{
		public int Id { get; set; }

		public string Content { get; set; }

		public bool IsCorrect { get; set; }

		public int      QuestionId { get; set; }
		public Question Question   { get; set; }
	}
}
using System.Collections.Generic;

namespace Quorum.Api.Controllers.Result.ResultModels
{
	public sealed class PassedQuestionResultModel
	{
		public string Content { get; set; }
		
		public int MaximumScore { get; set; }
		public int UserScore { get; set; }
		
		public ICollection<PassedAnswerResultModel> Answers { get; set; }

		public PassedQuestionResultModel()
		{
			Answers = new List<PassedAnswerResultModel>();
		}
	}
}
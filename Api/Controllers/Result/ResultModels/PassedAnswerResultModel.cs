namespace Quorum.Api.Controllers.Result.ResultModels
{
	public sealed class PassedAnswerResultModel
	{
		public string Content { get; set; }

		public bool IsCorrect     { get; set; }
		public bool IsUserCorrect { get; set; }
	}
}
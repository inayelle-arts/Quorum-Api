using System.Linq;
using System.Threading.Tasks;
using Quorum.BusinessCore.Entities;

namespace Quorum.BusinessCore.Models.Challenge
{
	internal sealed class ChallengeExecutor
	{
		public async Task ChallengeAsync(Test test, ChallengedTest challengedTest)
		{
			var map = from expected in test.Questions
			          let actual = challengedTest.Questions.First(c => c.SourceQuestionId == expected.Id)
			          select new { Expected = expected, Actual = actual };

			var tasks = from pair in map select Task.Run(() => CheckQuestion(pair.Expected, pair.Actual));

			await Task.WhenAll(tasks);

			challengedTest.MaximumScore = challengedTest.Questions.Sum(q => q.TotalScore);
			challengedTest.UserScore  = challengedTest.Questions.Sum(q => q.UserScore);
		}

		private void CheckQuestion(Question question, ChallengedQuestion challengedQuestion)
		{
			challengedQuestion.TotalScore = question.Answers.Count;

			var map = from expected in question.Answers
			          let actual = challengedQuestion.Answers.First(c => c.SourceAnswerId == expected.Id)
			          select new { Expected = expected, Actual = actual };

			challengedQuestion.UserScore = map.Count(pair => CheckAnswer(pair.Expected, pair.Actual));
		}

		private bool CheckAnswer(Answer expected, ChallengedAnswer actual)
		{
			return expected.IsCorrect == actual.IsUserCorrect;
		}
	}
}
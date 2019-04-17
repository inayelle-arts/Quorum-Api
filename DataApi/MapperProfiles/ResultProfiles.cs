using AutoMapper;
using Quorum.BusinessCore.Entities;
using Quorum.DataApi.Controllers.Result.ResultModels;
using Quorum.DataApi.Extensions;

namespace Quorum.DataApi.MapperProfiles
{
	internal sealed class ResultProfiles : Profile
	{
		public ResultProfiles()
		{
			CreateMap<ChallengedAnswer, PassedAnswerResultModel>()
					.ForField(c => c.SourceAnswer.Content, p => p.Content)
					.ForField(c => c.SourceAnswer.IsCorrect, p => p.IsCorrect);

			CreateMap<ChallengedQuestion, PassedQuestionResultModel>()
					.ForField(c => c.SourceQuestion.Content, p => p.Content);

			CreateMap<ChallengedTest, PassedTestResultModel>()
					.ForField(c => c.SourceTest.Name, p => p.Name);
		}
	}
}
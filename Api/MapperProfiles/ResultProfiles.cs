using AutoMapper;
using Quorum.Api.Controllers.Result.ResultModels;
using Quorum.Api.Extensions;
using Quorum.BusinessCore.Entities;

namespace Quorum.Api.MapperProfiles
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
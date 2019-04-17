using AutoMapper;
using Quorum.Api.Controllers.Challenge.ResultsModels;
using Quorum.Api.Controllers.Challenge.ViewModels;
using Quorum.Api.Extensions;
using Quorum.BusinessCore.Entities;

namespace Quorum.Api.MapperProfiles
{
	internal sealed class ChallengeProfiles : Profile
	{
		public ChallengeProfiles()
		{
			CreateMap<Answer, ChallengeAnswerResultModel>();
			CreateMap<Question, ChallengeQuestionResultModel>();
			CreateMap<Test, ChallengeTestResultModel>();

			CreateMap<ChallengedTestViewModel, ChallengedTest>();
			CreateMap<ChallengedQuestionViewModel, ChallengedQuestion>();

			CreateMap<ChallengedAnswerViewModel, ChallengedAnswer>()
					.ForField(view => view.IsCorrect, entity => entity.IsUserCorrect);
		}
	}
}
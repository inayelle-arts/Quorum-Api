using AutoMapper;
using Quorum.DataApi.Controllers.Challenge.ResultsModels;
using Quorum.DataApi.Controllers.Challenge.ViewModels;
using Quorum.Entities;
using Quorum.Shared.Extensions;

namespace Quorum.DataApi.Profiles
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
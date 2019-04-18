using AutoMapper;
using Quorum.BusinessCore.Entities;
using Quorum.DataApi.Controllers.Challenge.ResultsModels;
using Quorum.DataApi.Controllers.Challenge.ViewModels;
using Quorum.DataApi.Extensions;
using Quorum.Shared.Extensions;

namespace Quorum.DataApi.MapperProfiles
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
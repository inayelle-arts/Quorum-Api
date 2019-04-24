using AutoMapper;
using Quorum.DataApi.Controllers.Test.ViewModels;
using Quorum.Entities;

namespace Quorum.DataApi.Profiles
{
	internal sealed class CreateProfiles : Profile
	{
		public CreateProfiles()
		{
			CreateMap<CreateAnswerViewModel, Answer>();
			CreateMap<CreateQuestionViewModel, Question>();
			CreateMap<CreateTagViewModel, Tag>();
			CreateMap<CreateTestViewModel, Test>();
		}
	}
}
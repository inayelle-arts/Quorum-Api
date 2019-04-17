using AutoMapper;
using Quorum.Api.Controllers.Test.ViewModels;
using Quorum.BusinessCore.Entities;

namespace Quorum.Api.MapperProfiles
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
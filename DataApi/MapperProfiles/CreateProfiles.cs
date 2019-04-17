using AutoMapper;
using Quorum.BusinessCore.Entities;
using Quorum.DataApi.Controllers.Test.ViewModels;

namespace Quorum.DataApi.MapperProfiles
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
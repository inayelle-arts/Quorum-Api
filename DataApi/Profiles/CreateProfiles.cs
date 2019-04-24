using System.Linq;

using AutoMapper;

using Quorum.DataApi.Controllers.Test.ViewModels;
using Quorum.Entities;
using Quorum.Shared.Extensions;

namespace Quorum.DataApi.Profiles
{
	internal sealed class CreateProfiles : Profile
	{
		public CreateProfiles()
		{
			CreateMap<CreateAnswerViewModel, Answer>();
			CreateMap<CreateQuestionViewModel, Question>();
			CreateMap<CreateTagViewModel, Tag>();
			CreateMap<CreateTestViewModel, Test>().ForMember(test => test.Tags, opt =>
			{
				opt.MapFrom(so => so.Tags.Select(t => new Tag{Content = t}).ToList());
			});
		}
	}
}
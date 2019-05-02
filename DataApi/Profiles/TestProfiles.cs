using System.Linq;
using AutoMapper;
using Quorum.DataApi.Controllers.Test.ResultModels;
using Quorum.DataApi.Controllers.Test.ViewModels;
using Quorum.Entities;
using Quorum.Entities.Domain;
using Quorum.Shared.Extensions;

namespace Quorum.DataApi.Profiles
{
	internal sealed class TestProfiles : Profile
	{
		public TestProfiles()
		{
			CreateMap<CreateAnswerViewModel, Answer>();
			CreateMap<CreateQuestionViewModel, Question>();
			CreateMap<CreateTagViewModel, Tag>();

			CreateMap<CreateTestViewModel, Test>().ForMember(test => test.Tags,
					opt => { opt.MapFrom(so => so.Tags.Select(t => new Tag { Content = t }).ToList()); });

			CreateMap<Test, TestPreviewResultModel>().ForMember(test => test.Tags,
					                                         opt =>
					                                         {
						                                         opt.MapFrom(so => so.Tags.Select(t => t.Content));
					                                         })
			                                         .ForMember(test => test.QuestionsCount,
					                                         opt => { opt.MapFrom(so => so.Questions.Count); });
		}
	}
}
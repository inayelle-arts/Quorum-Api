using AutoMapper;
using Quorum.DataApi.Controllers.Sign.ViewModels;
using Quorum.Domain.Entities.Domain;

namespace Quorum.DataApi.Mapping
{
	internal sealed class SignProfiles : Profile
	{
		public SignProfiles()
		{
			CreateMap<SignUpViewModel, User>();
		}
	}
}
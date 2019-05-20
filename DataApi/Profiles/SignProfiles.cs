using AutoMapper;
using Quorum.DataApi.Controllers.Sign.ViewModels;
using Quorum.Entities.Domain;
using Quorum.Shared.Extensions;

namespace Quorum.DataApi.Profiles
{
	internal sealed class SignProfiles : Profile
	{
		public SignProfiles()
		{
			CreateMap<SignUpViewModel, User>();
			CreateMap<SignInViewModel, User>();
		}
	}
}
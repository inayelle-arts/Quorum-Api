using System.Collections.Generic;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Test.ViewModels
{
	public sealed class CreateTestViewModel: IDataTransferObject
	{
		public string Name { get; set; }
		public int    Time { get; set; }

		public ICollection<CreateTagViewModel>      Tags      { get; set; }
		public ICollection<CreateQuestionViewModel> Questions { get; set; }

		public CreateTestViewModel()
		{
			Tags      = new List<CreateTagViewModel>();
			Questions = new List<CreateQuestionViewModel>();
		}
	}
}
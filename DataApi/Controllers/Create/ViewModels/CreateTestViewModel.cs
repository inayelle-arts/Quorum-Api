using System.Collections.Generic;

using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Test.ViewModels
{
	public sealed class CreateTestViewModel: IDataTransferObject
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public ICollection<string> Tags { get; set; }

		public ICollection<CreateQuestionViewModel> Questions { get; set; }

		public CreateTestViewModel()
		{
			Tags      = new List<string>();
			Questions = new List<CreateQuestionViewModel>();
		}
	}
}
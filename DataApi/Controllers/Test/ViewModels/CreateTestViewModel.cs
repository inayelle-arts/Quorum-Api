using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Test.ViewModels
{
	public sealed class CreateTestViewModel: IDataTransferObject
	{
		[Required]
		public string Name { get; set; }
		
		[Required]
		public string Description { get; set; }

		[Required]
		public ICollection<string> Tags { get; set; }

		[Required]
		public ICollection<CreateQuestionViewModel> Questions { get; set; }
	}
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Challenge.ViewModels
{
	public sealed class ChallengedTestViewModel : IDataTransferObject
	{
		[Required]
		public int SourceTestId { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime ChallengedAt { get; set; }

		[Required]
		[MinLength(1)]
		public ICollection<ChallengedQuestionViewModel> Questions { get; set; }
	}
}
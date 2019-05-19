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
		public DateTime ChallengedAt { get; set; }

		[Required]
		public ICollection<ChallengedQuestionViewModel> Questions { get; set; }
	}
}
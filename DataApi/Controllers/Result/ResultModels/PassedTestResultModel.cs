using System;
using System.Collections.Generic;
using Quorum.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Result.ResultModels
{
	public sealed class PassedTestResultModel : IDataTransferObject
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int MaximumScore { get; set; }
		public int UserScore    { get; set; }

		public string UserEmail { get; set; }

		public DateTime ChallengedAt { get; set; }

		public ICollection<PassedQuestionResultModel> Questions { get; set; }
	}
}
using System.Collections.Generic;

using Quorum.Entities;
using Quorum.Entities.Domain;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Challenge.ResultsModels
{
	public sealed class ChallengeTestResultModel : IDataTransferObject
	{
		public int Id { get; set; }

		public string Name        { get; set; }
		public string Description { get; set; }

		public ICollection<Tag> Tags { get; set; }

		public ICollection<ChallengeQuestionResultModel> Questions { get; set; }

		public ChallengeTestResultModel()
		{
			Tags      = new List<Tag>();
			Questions = new List<ChallengeQuestionResultModel>();
		}
	}
}
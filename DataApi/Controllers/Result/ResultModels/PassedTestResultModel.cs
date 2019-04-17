using System.Collections.Generic;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Result.ResultModels
{
	public sealed class PassedTestResultModel : IDataTransferObject
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int MaximumScore { get; set; }
		public int UserScore    { get; set; }
		
		public ICollection<PassedQuestionResultModel> Questions { get; set; }

		public PassedTestResultModel()
		{
			Questions = new List<PassedQuestionResultModel>();
		}
	}
}
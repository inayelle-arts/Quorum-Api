using System;
using System.Collections.Generic;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Test.ResultModels
{
	public sealed class TestPreviewResultModel : IDataTransferObject
	{
		public int Id { get; set; }

		public string Name        { get; set; }
		public string Description { get; set; }

		public DateTime CreatedAt { get; set; }
		
		public bool ShuffleQuestions { get; set; }

		public int                 QuestionsCount { get; set; }
		public IEnumerable<string> Tags           { get; set; }
	}
}
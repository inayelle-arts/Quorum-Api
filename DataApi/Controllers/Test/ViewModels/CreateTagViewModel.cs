using System.ComponentModel.DataAnnotations;
using Quorum.Shared.Interfaces;

namespace Quorum.DataApi.Controllers.Test.ViewModels
{
	public sealed class CreateTagViewModel : IDataTransferObject
	{
		[Required]
		public string Content { get; set; }
	}
}
using LayerTemplateEdited.Core.Entities;

namespace LayerTemplateEdited.Entities.DTOs
{
	public class TemporaryDetailDto:IDto
	{
		public int TemporaryId { get; set; }
		public string TemporaryCategoryName { get; set; }
		public string TemporaryName { get; set; }
	}
}
  
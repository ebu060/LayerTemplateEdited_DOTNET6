using LayerTemplateEdited.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplateEdited.Entities.DTOs
{
	public class TemporaryDetailDto:IDto
	{
		public int TemporaryId { get; set; }
		public string TemporaryCategoryName { get; set; }
		public string TemporaryName { get; set; }
	}
}
  
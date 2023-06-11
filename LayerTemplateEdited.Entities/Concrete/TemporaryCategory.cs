using LayerTemplateEdited.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplateEdited.Entities.Concrete
{
	public class TemporaryCategory:IEntity
	{
		public int TemporaryCategoryId { get; set; }
		public string TemporaryCategoryName { get; set; }
	}
}

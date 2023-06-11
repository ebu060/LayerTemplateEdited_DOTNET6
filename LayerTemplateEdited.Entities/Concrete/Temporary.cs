using LayerTemplateEdited.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplateEdited.Entities.Concrete
{
	public class Temporary:IEntity
	{
		public int TemporaryId { get; set; }
		public int TemporaryCategoryId { get; set; }
		public string TemporaryName { get; set; }
	}
}

﻿using LayerTemplateEdited.Core.Entities;

namespace LayerTemplateEdited.Entities.Concrete
{
	public class Temporary:IEntity
	{
		public int TemporaryId { get; set; }
		public int TemporaryCategoryId { get; set; }
		public string TemporaryName { get; set; }
	}
}

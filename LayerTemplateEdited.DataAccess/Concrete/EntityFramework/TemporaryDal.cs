using LayerTemplateEdited.Core.DataAccess.EntityFramework;
using LayerTemplateEdited.DataAccess.Abstract;
using LayerTemplateEdited.Entities.Concrete;
using LayerTemplateEdited.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplateEdited.DataAccess.Concrete.EntityFramework
{
	public class TemporaryDal : EfEntityRepositoryBase<Temporary, TemporaryContext>, ITemporaryDal
	{
		public List<TemporaryDetailDto> GetTemporaryDetails()
		{
			using TemporaryContext context = new();
			var result = (from t in context.Temporaries
						  join tc in context.TemporaryCategories
						  on t.TemporaryCategoryId
						  equals tc.TemporaryCategoryId
						  select new TemporaryDetailDto
						  {
							  TemporaryId = t.TemporaryId,
							  TemporaryCategoryName = tc.TemporaryCategoryName,
							  TemporaryName = t.TemporaryName
						  }).ToList();

			return result;

		}
	}
}

using LayerTemplateEdited.Core.DataAccess;
using LayerTemplateEdited.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplateEdited.DataAccess.Abstract
{
	public interface ITemporaryCategoryDal: IEntityRepository<TemporaryCategory>
	{
	}
}

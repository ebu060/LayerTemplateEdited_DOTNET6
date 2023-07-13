using LayerTemplateEdited.Core.Utilities.Results;
using LayerTemplateEdited.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplateEdited.Business.Abstract
{
	public interface ITemporaryCategoryService
	{
		IDataResult<List<TemporaryCategory>> GetAll();
		IDataResult<TemporaryCategory> GetById(int categoryId);
	}
}

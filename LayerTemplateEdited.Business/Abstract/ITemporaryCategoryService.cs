using LayerTemplateEdited.Core.Utilities.Results;
using LayerTemplateEdited.Entities.Concrete;

namespace LayerTemplateEdited.Business.Abstract
{
	public interface ITemporaryCategoryService
	{
		IDataResult<List<TemporaryCategory>> GetAll();
		IDataResult<TemporaryCategory> GetById(int categoryId);
	}
}

using LayerTemplateEdited.Core.DataAccess.EntityFramework;
using LayerTemplateEdited.DataAccess.Abstract;
using LayerTemplateEdited.Entities.Concrete;

namespace LayerTemplateEdited.DataAccess.Concrete.EntityFramework
{
	public class TemporaryCategoryDal:EfEntityRepositoryBase<TemporaryCategory,TemporaryContext>,ITemporaryCategoryDal
	{
	}
}

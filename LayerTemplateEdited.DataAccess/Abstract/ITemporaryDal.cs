using LayerTemplateEdited.Core.DataAccess;
using LayerTemplateEdited.Entities.Concrete;
using LayerTemplateEdited.Entities.DTOs;

namespace LayerTemplateEdited.DataAccess.Abstract
{
	public interface ITemporaryDal:IEntityRepository<Temporary>
	{
		List<TemporaryDetailDto> GetTemporaryDetails();
	}
}

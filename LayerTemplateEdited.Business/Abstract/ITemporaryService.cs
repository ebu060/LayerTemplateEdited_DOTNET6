using LayerTemplateEdited.Core.Utilities.Results;
using LayerTemplateEdited.Entities.Concrete;
using LayerTemplateEdited.Entities.DTOs;


namespace LayerTemplateEdited.Business.Abstract
{
	public interface ITemporaryService
	{
		IDataResult<List<Temporary>> GetAll();
		IDataResult<Temporary> GetById(int id);
		IResult Add(Temporary temp);
		IDataResult<List<TemporaryDetailDto>> GetTemporaryDetails();
	}
}
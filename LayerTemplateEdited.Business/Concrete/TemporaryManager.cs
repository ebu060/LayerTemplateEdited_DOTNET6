using LayerTemplateEdited.Business.Abstract;
using LayerTemplateEdited.DataAccess.Abstract;
using LayerTemplateEdited.DataAccess.Concrete.EntityFramework;
using LayerTemplateEdited.Entities.Concrete;
using LayerTemplateEdited.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LayerTemplateEdited.Business.Concrete
{
	public class TemporaryManager : ITemporaryService
	{
		readonly ITemporaryDal _temporaryDal;

		public TemporaryManager(ITemporaryDal temporaryDal)
		{
			_temporaryDal = temporaryDal;
		}

		public List<Temporary> GetAll()
		{
			return _temporaryDal.GetAll();
		}

		public Temporary GetById(int id)
		{
			return _temporaryDal.Get(x => x.TemporaryId == id);
		}

		public List<TemporaryDetailDto> GetTemporaryDetails()
		{
			return _temporaryDal.GetTemporaryDetails();
		}
	}
}

﻿using LayerTemplateEdited.Business.Abstract;
using LayerTemplateEdited.Core.Utilities.Results;
using LayerTemplateEdited.DataAccess.Abstract;
using LayerTemplateEdited.Entities.Concrete;

namespace LayerTemplateEdited.Business.Concrete
{
	public class TemporaryCategoryManager : ITemporaryCategoryService
	{
		ITemporaryCategoryDal _temporaryCategoryDal;

		public TemporaryCategoryManager(ITemporaryCategoryDal temporaryCategoryDal)
		{
			_temporaryCategoryDal = temporaryCategoryDal;
		}

		public IDataResult<List<TemporaryCategory>> GetAll()
		{
			return new SuccessDataResult<List<TemporaryCategory>>(_temporaryCategoryDal.GetAll());
		}

		public IDataResult<TemporaryCategory> GetById(int categoryId)
		{
			return new SuccessDataResult<TemporaryCategory>(_temporaryCategoryDal.Get(x => x.TemporaryCategoryId == categoryId));
		}
	}
}

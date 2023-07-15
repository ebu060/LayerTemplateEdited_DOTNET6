using LayerTemplateEdited.Business.Abstract;
using LayerTemplateEdited.Business.BusinessAspects.Autofac;
using LayerTemplateEdited.Business.Constants;
using LayerTemplateEdited.Business.ValidationRules;
using LayerTemplateEdited.Core.Aspects.Autofac.Caching;
using LayerTemplateEdited.Core.Aspects.Autofac.Validation;
using LayerTemplateEdited.Core.Utilities.Business;
using LayerTemplateEdited.Core.Utilities.Results;
using LayerTemplateEdited.DataAccess.Abstract;
using LayerTemplateEdited.Entities.Concrete;
using LayerTemplateEdited.Entities.DTOs;

namespace LayerTemplateEdited.Business.Concrete
{
    public class TemporaryManager : ITemporaryService
	{
		ITemporaryDal _temporaryDal;
		ITemporaryCategoryService _temporaryCategoryService;

		public TemporaryManager(ITemporaryDal temporaryDal, ITemporaryCategoryService temporaryCategoryService)
		{
			_temporaryDal = temporaryDal;
			_temporaryCategoryService = temporaryCategoryService;
		}

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(TemporaryValidator))]
        [CacheRemoveAspect("ITemporaryService.Get")]
        public IResult Add(Temporary temp)
		{
			var result = BusinessRules.Run(
				CheckIfTemporaryCountOfCategoryCorrect(temp.TemporaryId), 
				CheckIfTemporaryNameExists(temp.TemporaryName),
				CheckIfCategoryLimitExceded()
				);

			if (result != null)
			{
				return result;
			}

			_temporaryDal.Add(temp);
			return new SuccessResult(Messages.TemporaryAdded);

		}
		[CacheAspect]
		public IDataResult<List<Temporary>> GetAll()
		{
			return new SuccessDataResult<List<Temporary>>(_temporaryDal.GetAll());
		}
        [CacheAspect]
        public IDataResult<Temporary> GetById(int id)
		{
			return new SuccessDataResult<Temporary>(_temporaryDal.Get(x => x.TemporaryId == id));
		}

		public IDataResult<List<TemporaryDetailDto>> GetTemporaryDetails()
		{
			return new SuccessDataResult<List<TemporaryDetailDto>>(_temporaryDal.GetTemporaryDetails());
		}

		private IResult CheckIfTemporaryCountOfCategoryCorrect(int categoryId)
		{
			var result = _temporaryDal.GetAll(p => p.TemporaryCategoryId == categoryId).Count;
			if (result >= 15)
			{
				return new ErrorResult(Messages.ProductCountOfCategoryError);
			}
			return new SuccessResult();
		}

		private IResult CheckIfTemporaryNameExists(string temporaryName)
		{
			var result = _temporaryDal.GetAll(x => x.TemporaryName == temporaryName).Any();
			if (result)
			{
				return new ErrorResult(Messages.ProductNameAlreadyExists);
			}
			return new SuccessResult();
		}

		private IResult CheckIfCategoryLimitExceded()
		{
			var result = _temporaryCategoryService.GetAll();

			if(result.Data.Count> 15)
			{
				return new ErrorResult();
			}
			return new SuccessResult();
		}
	}
}

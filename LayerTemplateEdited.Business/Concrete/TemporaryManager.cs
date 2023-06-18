using FluentValidation;
using LayerTemplateEdited.Business.Abstract;
using LayerTemplateEdited.Business.Constants;
using LayerTemplateEdited.Business.ValidationRules;
using LayerTemplateEdited.Core.Aspects.Autofac.Validation;
using LayerTemplateEdited.Core.CrossCuttingConcerns.Validation;
using LayerTemplateEdited.Core.Utilities.Results;
using LayerTemplateEdited.DataAccess.Abstract;
using LayerTemplateEdited.Entities.Concrete;
using LayerTemplateEdited.Entities.DTOs;
using System.ComponentModel.DataAnnotations;

namespace LayerTemplateEdited.Business.Concrete
{
	public class TemporaryManager : ITemporaryService
	{
		readonly ITemporaryDal _temporaryDal;

		public TemporaryManager(ITemporaryDal temporaryDal)
		{
			_temporaryDal = temporaryDal;
		}

		[ValidationAspect(typeof(TemporaryValidator))]
		public IResult Add(Temporary temp)
		{
			_temporaryDal.Add(temp);
			return new SuccessResult(Messages.TemporaryAdded);
		}
		 
		public IDataResult<List<Temporary>> GetAll()
		{
			return new SuccessDataResult<List<Temporary>>(_temporaryDal.GetAll());
		}
		 
		public IDataResult<Temporary> GetById(int id)
		{
			return new SuccessDataResult<Temporary>(_temporaryDal.Get(x => x.TemporaryId == id)); 
		}

		public IDataResult<List<TemporaryDetailDto>>  GetTemporaryDetails()
		{
			return new SuccessDataResult<List<TemporaryDetailDto>>(_temporaryDal.GetTemporaryDetails()); 
		}
	}
}

using LayerTemplateEdited.Business.Abstract;
using LayerTemplateEdited.Business.Concrete;
using LayerTemplateEdited.DataAccess.Abstract;
using LayerTemplateEdited.DataAccess.Concrete.EntityFramework;
using LayerTemplateEdited.Entities.Concrete;
using LayerTemplateEdited.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LayerTemplateEdited.API.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class TemporaryController : ControllerBase
	{
		[HttpGet("GetAll", Name = "GetAll")]
		public List<Temporary> GetAll()
		{
			TemporaryManager temporaryManager = new (new TemporaryDal());
			return temporaryManager.GetAll();
		}

		[HttpGet("GetDetaill", Name = "GetDetaill")]
		public List<TemporaryDetailDto> GetDetaill()
		{
			TemporaryManager temporaryManager = new(new TemporaryDal());
			return temporaryManager.GetTemporaryDetails();
		}
	}
}

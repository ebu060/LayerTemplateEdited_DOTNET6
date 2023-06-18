using LayerTemplateEdited.Business.Abstract;
using LayerTemplateEdited.Business.Concrete;
using LayerTemplateEdited.Core.Utilities.Results;
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

		ITemporaryService _temporaryService;

		public TemporaryController(ITemporaryService temporaryService)
		{
			_temporaryService = temporaryService;
		}


		[HttpGet("GetAll", Name = "GetAll")]
		public IActionResult GetAll()
		{
			return Ok(_temporaryService.GetAll());
		}

		[HttpGet("GetDetaill", Name = "GetDetaill")]
		public IActionResult GetDetaill()
		{
			return Ok(_temporaryService.GetTemporaryDetails());
		}

		[HttpPost]
		public IActionResult Post(Temporary data)
		{
			var result = _temporaryService.Add(data);
			if (result.Success)
			{
				return Ok();
			}
			else
			{
				return BadRequest();
			}
		}
	}
}

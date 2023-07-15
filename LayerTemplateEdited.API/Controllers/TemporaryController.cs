using LayerTemplateEdited.Business.Abstract;
using LayerTemplateEdited.Entities.Concrete;
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

        [HttpGet("GetById", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(_temporaryService.GetById(id));
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
				return Ok(result);
			}
			else
			{
				return BadRequest();
			}
		}
	}
}

using LayerTemplateEdited.Core.Entities;

namespace LayerTemplateEdited.Entities.DTOs
{
	public class UserForLoginDto : IDto
	{
		public string Email { get; set; }
		public string Password { get; set; }
	}
}

using LayerTemplateEdited.Core.Entities.Concrete;
using LayerTemplateEdited.Core.Utilities.Results;
using LayerTemplateEdited.Core.Utilities.Security.JWT;
using LayerTemplateEdited.Entities.DTOs;

namespace LayerTemplateEdited.Business.Abstract
{
	public interface IAuthService
	{
		IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
		IDataResult<User> Login(UserForLoginDto userForLoginDto);
		IResult UserExists(string email);
		IDataResult<AccessToken> CreateAccessToken(User user);
	}
}

using LayerTemplateEdited.Core.Entities.Concrete;

namespace LayerTemplateEdited.Core.Utilities.Security.JWT
{
	public interface ITokenHelper
	{
		AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
	}
}

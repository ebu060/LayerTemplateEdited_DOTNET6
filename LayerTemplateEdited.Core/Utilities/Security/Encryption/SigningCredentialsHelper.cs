using Microsoft.IdentityModel.Tokens;

namespace LayerTemplateEdited.Core.Utilities.Security.Encryption
{
	public class SigningCredentialsHelper
	{
		public static SigningCredentials CreateSigningCredentials(SecurityKey security)
		{
			return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);
		}
	}
}

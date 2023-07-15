using LayerTemplateEdited.Core.DataAccess;
using LayerTemplateEdited.Core.Entities.Concrete;

namespace LayerTemplateEdited.DataAccess.Abstract
{
	public interface IUserDal : IEntityRepository<User>
	{
		List<OperationClaim> GetClaims(User user);
	}
}

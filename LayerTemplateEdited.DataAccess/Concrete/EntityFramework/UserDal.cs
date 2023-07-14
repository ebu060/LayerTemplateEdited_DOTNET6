using LayerTemplateEdited.Core.DataAccess.EntityFramework;
using LayerTemplateEdited.Core.Entities.Concrete;
using LayerTemplateEdited.DataAccess.Abstract;

namespace LayerTemplateEdited.DataAccess.Concrete.EntityFramework
{
	public class UserDal : EfEntityRepositoryBase<User, TemporaryContext>, IUserDal
	{
		public List<OperationClaim> GetClaims(User user)
		{
			using (var context = new TemporaryContext())
			{
				var result = from operationClaim in context.OperationClaims
							 join userOperationClaim in context.UserOperationClaims
								 on operationClaim.Id equals userOperationClaim.OperationClaimId
							 where userOperationClaim.UserId == user.Id
							 select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
				return result.ToList();

			}
		}
	}
}

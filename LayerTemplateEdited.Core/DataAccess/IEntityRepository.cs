using LayerTemplateEdited.Core.Entities;
using System.Linq.Expressions;

namespace LayerTemplateEdited.Core.DataAccess
{
	public interface IEntityRepository<T> where T : class,IEntity
	{
		List<T> GetAll(Expression<Func<T, bool>>? predicate = null);
		T Get(Expression<Func<T, bool>> predicate);
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);

	}
}

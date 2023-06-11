using LayerTemplateEdited.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace LayerTemplateEdited.Core.DataAccess.EntityFramework
{
	public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
		where TEntity : class, IEntity, new()
		where TContext : DbContext, new()
	{
		public void Add(TEntity entity)
		{
			using TContext context = new();
			var addedEntity = context.Entry(entity);
			addedEntity.State = EntityState.Added;
			context.SaveChanges();
		}

		public void Delete(TEntity entity)
		{
			using TContext context = new();
			var deletedEntity = context.Entry(entity);
			deletedEntity.State = EntityState.Deleted;
			context.SaveChanges();
		}

		public TEntity Get(Expression<Func<TEntity, bool>> predicate)
		{
			using TContext context = new();
			return context.Set<TEntity>().SingleOrDefault(predicate);
		}

		public List<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null)
		{
			using TContext context = new();
			return predicate == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(predicate).ToList();
		}

		public void Update(TEntity entity)
		{
			using TContext context = new();
			var updatedEntity = context.Entry(entity);
			updatedEntity.State = EntityState.Modified;
			context.SaveChanges();
		}
	}
}

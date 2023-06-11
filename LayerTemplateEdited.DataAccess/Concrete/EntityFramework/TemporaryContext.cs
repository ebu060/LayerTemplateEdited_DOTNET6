using LayerTemplateEdited.Entities.Concrete;
using Microsoft.EntityFrameworkCore;


namespace LayerTemplateEdited.DataAccess.Concrete.EntityFramework
{
	public class TemporaryContext:DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=LayerTemplateEdited;Trusted_Connection=true");
		}

		public DbSet<Temporary> Temporaries { get; set; }
		public DbSet<TemporaryCategory> TemporaryCategories { get; set; }
	}
}

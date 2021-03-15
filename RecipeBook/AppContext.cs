using System.Data.Entity;

namespace RecipeBook
{
    class AppContext : DbContext
    {
        public AppContext() : base("DefaultConnection")
        {
        }
        public DbSet<Recipe> Recipes { get; set; }
    }
}

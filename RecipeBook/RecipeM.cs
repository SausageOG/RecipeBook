using System.Collections.Generic;
using System.Data.Entity;

namespace RecipeBook
{
    class RecipeM
    {
        AppContext db;
        IEnumerable<Recipe> recipes;
        public IEnumerable<Recipe> Recipes { get { return recipes; } set { recipes = value; } }
        public RecipeM()
        {
            db = new AppContext();
            db.Recipes.Load();
            Recipes = db.Recipes.Local.ToBindingList();
        }

        public void AddRecipe(Recipe recipe)
        {
            db.Recipes.Add(recipe);
            db.SaveChanges();
        }
        public void DeleteRecipe(Recipe recipe)
        {
            db.Recipes.Remove(recipe);
            db.SaveChanges();
        }
        public void EditRecipe(Recipe recipe)
        {
            
        }
    }
}

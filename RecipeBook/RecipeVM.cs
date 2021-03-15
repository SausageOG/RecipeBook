using Prism.Commands;
using System.Collections.Generic;

namespace RecipeBook
{
    class RecipeVM
    {
        RecipeM recipeM;
        public IEnumerable<Recipe> Recipes => recipeM.Recipes;


        public string Title { get; set; }
        public string Description { get; set; }

        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand<Recipe> RemoveCommand { get; private set; }
        public RecipeVM()
        {
            recipeM = new RecipeM();

            AddCommand = new DelegateCommand(Add);
            RemoveCommand = new DelegateCommand<Recipe>(Remove);
        }
        private void Add()
        {
            Recipe newRecipe = new Recipe();
            newRecipe.Title = Title;
            newRecipe.Description = Description;

            recipeM.AddRecipe(newRecipe);
        }
        private void Remove(Recipe recipe)
        {
            recipeM.DeleteRecipe(recipe);
        }
    }
}

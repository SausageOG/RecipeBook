using Prism.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace RecipeBook
{
    class RecipeVM : INotifyPropertyChanged
    {
        RecipeM recipeM;
        public IEnumerable<Recipe> Recipes => recipeM.Recipes;


        public bool isChecked { get; set; }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        private string desc;
        public string Description
        {
            get { return desc; }
            set
            {
                desc = value;
                OnPropertyChanged("Description");
            }
        }

        public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand<Recipe> RemoveCommand { get; private set; }
        public DelegateCommand<Recipe> EditCommand { get; private set; }



        public RecipeVM()
        {
            recipeM = new RecipeM();

            AddCommand = new DelegateCommand(Add);
            RemoveCommand = new DelegateCommand<Recipe>(Remove);
            EditCommand = new DelegateCommand<Recipe>(Edit);
           
        }


        private void Add()
        {
            Recipe newRecipe = new Recipe();
            newRecipe.Title = Title;
            newRecipe.Description = Description;

            recipeM.AddRecipe(newRecipe);

            ClearTextBoxes();
        }
        private void Remove(Recipe recipe)
        {
            if (recipe != null)
            {
                recipeM.DeleteRecipe(recipe);
            }
        }
        private void Edit(Recipe recipe)
        {
            if (recipe != null)
            {
                if (Title == "" && Description == "" || Title == null && Description == null)
                {
                    Title = recipe.Title;
                    Description = recipe.Description;
                }
                else
                {
                    recipeM.DeleteRecipe(recipe);

                    Recipe newRecipe = new Recipe();
                    newRecipe.Title = Title;
                    newRecipe.Description = Description;

                    recipeM.AddRecipe(newRecipe);

                    ClearTextBoxes();
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private void ClearTextBoxes()
        {
            Title = "";
            Description = "";
        }
    }
}

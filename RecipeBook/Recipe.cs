namespace RecipeBook
{
    class Recipe
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }

        private string title;
        public string Title { get { return title; } set { title = value; } }

        private string desc;
        public string Description { get { return desc; } set { desc = value; } }
    }
}

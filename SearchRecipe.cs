using System.Collections.Generic;
using System.Windows.Forms;

namespace FoodApp
{
    public partial class SearchRecipe : UserControl
    {
        static RecipeService recipeService = new RecipeService();
        public List<Ingredient> availableIngredients = recipeService.GetIngredientsFromDatabase();
        public SearchRecipe()
        {
            InitializeComponent();
        }

        private void cbIngredient_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            cbIngredient.DataSource = availableIngredients;
            cbIngredient.DisplayMember = "name";
        }
    }
}

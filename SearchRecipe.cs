using System.Collections.Generic;
using System.Windows.Forms;

namespace FoodApp
{
    public partial class SearchRecipe : UserControl
    {
        public static RecipeService recipeService = new RecipeService();
        public SearchRecipe()
        {
            InitializeComponent();
            searchResults1.Visible = false;
        }

        private void BindCbIngredient()
        {
            cbIngredient.DataSource = recipeService.GetIngredientsFromDatabase();
            cbIngredient.DisplayMember = "name";
            cbIngredient.ValueMember = "ID";
        }
        private void cbIngredient_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string selectedIngredient = (string)cbIngredient.SelectedItem;
            int count = 0;
            int resultIndex = -1;
            resultIndex = cbIngredient.FindStringExact(selectedIngredient);
            while (resultIndex != -1)
            {
                recipeService.enteredIngredients[count].name = selectedIngredient;
                recipeService.enteredIngredients[count].ID = resultIndex;
                this.labelEnteredIngredients.Text += selectedIngredient + "\r\n";
                cbIngredient.Items.RemoveAt(resultIndex);
                count += 1;
                resultIndex = cbIngredient.FindStringExact(selectedIngredient,
                    resultIndex);

            }

        }

        private void btnStartSearch_Click(object sender, System.EventArgs e)
        {
            recipeService.SearchRecipes(recipeService.enteredIngredients, recipeService.collectedRecipes);
            searchResults1.Visible = true;

        }

        private void btnAddOtherIngredient_Click(object sender, System.EventArgs e)
        {

        }
    }
}

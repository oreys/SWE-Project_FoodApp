using System;
using System.Windows.Forms;

namespace FoodApp
{
    public partial class ShowRecipe : UserControl
    {
        public ShowRecipe()
        {
            InitializeComponent();
            Load += ShowRecipe_Load;
        }
        private int GetIndexFromID(int givenID)
        {
            int index = 0;
            for (int i = 0; i < SearchRecipe.recipeService.collectedRecipes.Count; i++)
            {
                if (SearchRecipe.recipeService.collectedRecipes[i].id == givenID)
                {
                    index = i;
                    return index;
                }
            }
            throw new ArgumentException(givenID + " could not be found in collected recipes IDs");
        }
        //ids überprüfen und index übergeben
        private void ShowRecipe_Load(object sender, EventArgs e)
        {

            SearchResults searchResults = new SearchResults();
            flowPnlShowRecipe.FlowDirection = FlowDirection.TopDown;
            int id = searchResults.selectedID;//get index of selected recipe for collected recipes
            label1.Text = id.ToString();
            Label recipeName = new Label();
            recipeName.AutoSize = true;
            int index = GetIndexFromID(id);
            recipeName.Text = SearchRecipe.recipeService.collectedRecipes[index].name;
            Label recipeDescription = new Label();
            recipeDescription.AutoSize = true;
            recipeDescription.Text = SearchRecipe.recipeService.collectedRecipes[index].description;
            Label ingredients = new Label();
            ingredients.AutoSize = true;
            int countI = 0; // counter for ingredients
            foreach (Ingredient ingredient in SearchRecipe.recipeService.collectedRecipes[index].ingredients)
            {
                ingredients.Text += SearchRecipe.recipeService.collectedRecipes[index].ingredients[countI].amount + " ";
                ingredients.Text += SearchRecipe.recipeService.collectedRecipes[index].ingredients[countI].unit + " ";
                ingredients.Text += SearchRecipe.recipeService.collectedRecipes[index].ingredients[countI].name + "\r\n";
                countI++;
            }

            Label steps = new Label();
            steps.AutoSize = true;
            int countS = 0; // counter for ingredients
            foreach (Step step in SearchRecipe.recipeService.collectedRecipes[index].steps)
            {
                steps.Text += SearchRecipe.recipeService.collectedRecipes[index].steps[countS].number + ". ";
                steps.Text += SearchRecipe.recipeService.collectedRecipes[index].steps[countS].description + "\r\n";
                countS++;
            }


        }

        private void flowPnlShowRecipe_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}

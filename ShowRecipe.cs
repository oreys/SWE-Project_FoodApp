using System;
using System.Windows.Forms;

namespace FoodApp
{
    /// <summary>
    /// Is part of the GUI and shows the clicked recipe.
    /// </summary>
    public partial class ShowRecipe : UserControl
    {
        public int id;
        public ShowRecipe()
        {
            InitializeComponent();
            Load += ShowRecipe_Load;
        }
        /// <summary>
        /// Loads the view for the selected recipe.
        /// </summary>

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

        private void ShowRecipe_Load(object sender, EventArgs e)
        {

            SearchResults searchResults = new SearchResults();
            flowPnlShowRecipe.FlowDirection = FlowDirection.TopDown;
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
            int countS = 0; // counter for steps
            foreach (Step step in SearchRecipe.recipeService.collectedRecipes[index].steps)
            {
                steps.Text += SearchRecipe.recipeService.collectedRecipes[index].steps[countS].number + ". ";
                steps.Text += SearchRecipe.recipeService.collectedRecipes[index].steps[countS].description + "\r\n";
                countS++;
            }
            flowPnlShowRecipe.Controls.Add(recipeName);
            flowPnlShowRecipe.Controls.Add(recipeDescription);
            flowPnlShowRecipe.Controls.Add(ingredients);
            flowPnlShowRecipe.Controls.Add(steps);
            this.Controls.Add(flowPnlShowRecipe);


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

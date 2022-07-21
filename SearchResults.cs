using System;
using System.Drawing;
using System.Windows.Forms;

namespace FoodApp
{
    public partial class SearchResults : UserControl
    {
        public SearchResults()
        {
            InitializeComponent();
        }

        private void gbRecipe_Enter(object sender, EventArgs e)
        {

        }


        private void DisplayRecipes()
        {
            int countR = 0;
            int countControls = 1;
            flowPnl.FlowDirection = FlowDirection.TopDown;
            foreach (Recipe recipe in SearchRecipe.recipeService.collectedRecipes)
            {
                GroupBox gbIngredient = new GroupBox();
                Label labelRecipeName = new Label();
                Label labelRecipeDescription = new Label();
                gbRecipe.Name = "gbIngredient" + countControls;
                labelRecipeName.Name = "labelRecipeName" + countControls;
                labelRecipeDescription.Name = "labelRecipeDescription" + countControls;
                gbRecipe.MinimumSize = new Size(750, 250);
                gbRecipe.AutoSize = true;
                labelRecipeName.Location = new Point(45, 55);
                labelRecipeDescription.Location = new Point(200, 55);
                labelRecipeName.MaximumSize = new Size(120, 50);
                labelRecipeDescription.MaximumSize = new Size(600, 200);
                labelRecipeName.AutoSize = true;
                labelRecipeDescription.AutoSize = true;
                labelRecipeName.Text = SearchRecipe.recipeService.collectedRecipes[countR].name;
                labelRecipeDescription.Text = SearchRecipe.recipeService.collectedRecipes[countR].description;
                gbRecipe.Controls.Add(labelRecipeName);
                gbRecipe.Controls.Add(labelRecipeDescription);
                flowPnl.Controls.Add(gbRecipe);


                countR++;
            }
        }


    }
}

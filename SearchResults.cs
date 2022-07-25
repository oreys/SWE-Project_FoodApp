using System;
using System.Drawing;
using System.Windows.Forms;

namespace FoodApp
{
    public partial class SearchResults : UserControl
    {
        public int selectedID;
        public SearchResults()
        {
            InitializeComponent();

        }

        private void gbRecipe_Enter(object sender, EventArgs e)
        {

        }

        private void gbRecipe_Click(object sender, System.EventArgs e, int countR)
        {
            SearchRecipe.recipeService.selectedRecipe.id = countR;
        }

        private void DisplayRecipes()
        {
            int countR = 0;
            int countControls = 1;
            flowPnl.FlowDirection = FlowDirection.TopDown;
            flowPnl.AutoScroll = true;
            foreach (Recipe recipe in SearchRecipe.recipeService.collectedRecipes)
            {
                Panel gbRecipe = new Panel();
                Label labelRecipeName = new Label();
                Label labelRecipeDescription = new Label();
                gbRecipe.Name = "gbRecipe" + countControls;
                labelRecipeName.Name = recipe.id.ToString();
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
                labelRecipeName.Click += new EventHandler(lbl_Click);
                gbRecipe.Controls.Add(labelRecipeName);
                gbRecipe.Controls.Add(labelRecipeDescription);
                flowPnl.Controls.Add(gbRecipe);
                countR++;
            }
        }

        protected void lbl_Click(object sender, EventArgs e)
        {
            //attempt to cast the sender as a label
            Label lbl = sender as Label;

            //if the cast was successful (i.e. not null), navigate to the site
            if (lbl != null)
            {
                selectedID = Convert.ToInt32(lbl.Name);
                showRecipe1.id = selectedID;
                showRecipe1.Visible = true;

            }
        }

        private void SearchResults_Load(object sender, EventArgs e)
        {
            DisplayRecipes();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void showRecipe1_Load(object sender, EventArgs e)
        {

        }
    }
}

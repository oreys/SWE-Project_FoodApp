using System.Windows.Forms;

namespace FoodApp
{
    public partial class ShowRecipe : UserControl
    {
        public ShowRecipe()
        {
            InitializeComponent();
        }
        public void LoadShowRecipe()
        {
            flowPnlShowRecipe.FlowDirection = FlowDirection.TopDown;
            int index = SearchRecipe.recipeService.selectedRecipe.id;//get index of selected recipe for collected recipes
            Label recipeName = new Label();
            recipeName.AutoSize = true;
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
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FoodApp
{
    public partial class SearchRecipe : UserControl
    {
        public static RecipeService recipeService = new RecipeService();
        public SearchRecipe()
        {
            InitializeComponent();
            Load += cbIngredient_Load;
            searchResults1.Visible = false;
        }


        private DataTable getIngredientsTable()
        {
            DataTable ingredientsTable = new DataTable();
            SqlConnection connection;
            string connectionString = DatabaseFunctions.getConnectionString();

            //extract Ingredients
            string queryI = "SELECT * FROM ingredients";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryI, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(ingredientsTable);
            }

            return ingredientsTable;
        }
        private void cbIngredient_Load(object sender, System.EventArgs e)
        {
            cbIngredient.DataSource = recipeService.GetIngredientsFromDatabase();
            cbIngredient.DisplayMember = "ingredient";
            cbIngredient.ValueMember = "ID";
        }
        private void cbIngredient_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            /*string selectedIngredient = (string)cbIngredient.SelectedItem;
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
                resultIndex = cbIngredient.FindStringExact(selectedIngredient, resultIndex);

            }*/

        }

        private void btnStartSearch_Click(object sender, System.EventArgs e)
        {
            List<ComboBox> cbListI = new List<ComboBox>();
            cbListI = pnlIngredient.Controls.OfType<ComboBox>().ToList();
            foreach (ComboBox cbIngredient in cbListI)
            {
                Ingredient ingredient = new Ingredient();
                ingredient.ID = Convert.ToInt32(cbIngredient.SelectedValue);
                recipeService.enteredIngredients.Add(ingredient);
            }

            recipeService.collectedRecipes = recipeService.SearchRecipes(recipeService.enteredIngredients, recipeService.collectedRecipes);
            searchResults1.Visible = true;

        }

        private void btnAddOtherIngredient_Click(object sender, System.EventArgs e)
        {
            int count = pnlIngredient.Controls.OfType<ComboBox>().ToList().Count;


            ComboBox combobox1 = new ComboBox();
            combobox1.Location = new System.Drawing.Point(15, (30 * count));
            combobox1.Size = new System.Drawing.Size(225, 21);
            combobox1.Name = "cbIngredient" + (count + 1);
            combobox1.ValueMember = "ID";
            combobox1.DisplayMember = "ingredient";
            combobox1.DataSource = recipeService.GetIngredientsFromDatabase();
            pnlIngredient.Controls.Add(combobox1);

            pnlIngredient.Size = new System.Drawing.Size(338, 38 * (count + 1) + 7);
            btnAddOtherIngredient.Location = new System.Drawing.Point(425, 24 * (count + 1) + 33);
            btnStartSearch.Location = new System.Drawing.Point(425, 24 * (count + 1) + 15);
        }

        private void searchResults1_Load(object sender, System.EventArgs e)
        {
            DisplayRecipes();
        }
        private void DisplayRecipes()
        {
            int countR = 0;
            int countControls = 1;
            FlowLayoutPanel flowPnl = new FlowLayoutPanel();

            flowPnl.FlowDirection = FlowDirection.TopDown;
            flowPnl.AutoScroll = true;
            foreach (Recipe recipe in SearchRecipe.recipeService.collectedRecipes)
            {
                Panel gbRecipe = new Panel();
                Label labelRecipeName = new Label();
                Label labelRecipeDescription = new Label();
                gbRecipe.Name = "gbRecipe" + countControls;
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FoodApp
{
    /// <summary>
    /// Is part of the GUI and shows the view for searching for recipes.
    /// </summary>
    public partial class SearchRecipe : UserControl
    {
        public static RecipeService recipeService = new RecipeService();
        public SearchRecipe()
        {
            InitializeComponent();
            Load += cbIngredient_Load;
            searchResults1.Visible = false;

            Click += btnRecipeName_Click;

            //recipeService.enteredIngredients = recipeService.GetIngredientIDs();//remove again!!!!
            //labelTest.Text = recipeService.enteredIngredients[6].ID.ToString();//same here + label in entwurf
        }

        /// <summary>
        /// Gets all data related to ingredients and stores them in a datatable.
        /// </summary>
        /// <returns>DataTable</returns>
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
            //Testrezept
            /*Recipe TestRecipe = new Recipe();
            TestRecipe.name = "Wassersuppe";
            TestRecipe.description = "blabla";
            List<Ingredient> testIngredientList = new List<Ingredient>();
            Ingredient testIngredient = new Ingredient();
            testIngredient.name = "Wasser";
            testIngredient.ID = 1;
            testIngredientList.Add(testIngredient);
            TestRecipe.ingredients = testIngredientList;
            recipeService.collectedRecipes.Add(TestRecipe);*/
            if (recipeService.collectedRecipes.Count == 0)
            {
                Label warningNoRecipesFound = new Label();
                warningNoRecipesFound.AutoSize = true;
                warningNoRecipesFound.Text = "No recipes found!";
                warningNoRecipesFound.Location = new Point(200, 15);
                this.Controls.Add(warningNoRecipesFound);
            }
            else
            {

                searchResults1.Visible = true;
                Load += searchResults1_Load_1;
            }

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

        private void SearchResults1_Load(object sender, System.EventArgs e)
        {
            DisplayRecipes();
        }
        private void btnRecipeName_Click(object sender, System.EventArgs e)
        {
            //showRecipe1.Visible = true;
        }

        /// <summary>
        /// Shows the selected recipe.
        /// </summary>
        private void ShowRecipe()
        {
            //flowPnlShowRecipe
            Label recipeName = new Label();
            recipeName.AutoSize = true;
            // recipeName.Text = recipeService.collectedRecipes
            Label recipeShortDescription = new Label();
            recipeShortDescription.AutoSize = true;
            Label recipeIngredients = new Label();
            recipeIngredients.AutoSize = true;
            Label recipeSteps = new Label();
            recipeSteps.AutoSize = true;
        }


        private void DisplayRecipes()
        {
            // Creating and setting the
            // properties of FlowLayoutPanel
            FlowLayoutPanel fl = new FlowLayoutPanel();
            fl.Location = new Point(380, 124);
            fl.Size = new Size(216, 57);
            fl.Name = "Myflowpanel";
            fl.Font = new Font("Calibri", 12);
            fl.FlowDirection = FlowDirection.RightToLeft;
            fl.BorderStyle = BorderStyle.Fixed3D;
            fl.ForeColor = Color.BlueViolet;
            fl.Visible = true;

            // Adding this control to the form
            this.Controls.Add(fl);

            // Creating and setting the
            // properties of radio buttons

            RadioButton f1 = new RadioButton();
            f1.Location = new Point(3, 3);
            f1.Size = new Size(95, 20);
            f1.Text = "R1";

            // Adding this control
            // to the FlowLayoutPanel
            fl.Controls.Add(f1);
            /*int countR = 0;
            int countControls = 1;
            FlowLayoutPanel flowPnl = new FlowLayoutPanel();
            flowPnl.Location = new Point(0, 0);
            flowPnl.Visible = true;
            flowPnl.Dock = DockStyle.Fill;
            flowPnl.FlowDirection = FlowDirection.TopDown;
            flowPnl.AutoScroll = true;
            this.Controls.Add(flowPnl);
            //testButton
            Button testButton = new Button();
            testButton.Size = new Size(50, 50);
            testButton.Text = "Test";
            flowPnl.Controls.Add(testButton);*/
            /*foreach (Recipe recipe in SearchRecipe.recipeService.collectedRecipes)
            {
                Panel pnlRecipe = new Panel();
                Button btnRecipeName = new Button();
                Label labelRecipeDescription = new Label();
                pnlRecipe.AutoSize = true;
                btnRecipeName.Visible = true;
                pnlRecipe.Visible = true;
                pnlRecipe.Name = "pnlRecipe" + countControls;
                btnRecipeName.Name = "labelRecipeName" + countControls;
                labelRecipeDescription.Name = "labelRecipeDescription" + countControls;
                pnlRecipe.MinimumSize = new Size(750, 250);

                btnRecipeName.Location = new Point(45, 55);
                labelRecipeDescription.Location = new Point(200, 55);
                btnRecipeName.MaximumSize = new Size(120, 50);
                labelRecipeDescription.MaximumSize = new Size(600, 200);
                btnRecipeName.AutoSize = true;
                labelRecipeDescription.AutoSize = true;
                btnRecipeName.Text = SearchRecipe.recipeService.collectedRecipes[countR].name;
                labelRecipeDescription.Text = SearchRecipe.recipeService.collectedRecipes[countR].description;

                pnlRecipe.Controls.Add(btnRecipeName);
                pnlRecipe.Controls.Add(labelRecipeDescription);
                flowPnl.Controls.Add(pnlRecipe);
                countR++;
                countControls++;
            }
            */
            //when btnrecipenamepanel click 
        }

        private void labelTest_Click(object sender, EventArgs e)
        {

        }

        private void searchResults1_Load_1(object sender, EventArgs e)
        {
            searchResults1.Show();
            DisplayRecipes();
        }
    }
}

using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace FoodApp
{
    /// <summary>
    /// Is part of the GUI and shows the view for adding new recipes or ingredients
    /// </summary>
    public partial class AddNewRecipe : UserControl
    {

        public AddNewRecipe()
        {
            InitializeComponent();
        }

        private void btnAddNewRecipe_Click(object sender, EventArgs e)
        {
            var recipeService = new RecipeService();
            Recipe newRecipe = new Recipe();
            List<Ingredient> ingredients = new List<Ingredient>();
            List<ComboBox> cbListI = new List<ComboBox>();
            List<TextBox> txtListI = new List<TextBox>();
            List<ComboBox> cbListU = new List<ComboBox>();
            List<Step> steps = new List<Step>();
            List<Label> lblListS = new List<Label>();
            List<TextBox> txtListS = new List<TextBox>();

            newRecipe.name = txtNewRecipeName.Text;
            newRecipe.description = txtNewRecipeDescription.Text;

            int countI = pnlAmount.Controls.OfType<TextBox>().ToList().Count;
            cbListI = pnlIngredients.Controls.OfType<ComboBox>().ToList();
            txtListI = pnlAmount.Controls.OfType<TextBox>().ToList();
            cbListU = pnlIngredients.Controls.OfType<ComboBox>().ToList();

            for (int i = 0; i < countI; i++)
            {
                Ingredient ingredient = new Ingredient();
                ComboBox comboBoxI = new ComboBox();
                TextBox txtBoxI = new TextBox();
                ComboBox comboBoxU = new ComboBox();

                comboBoxI = cbListI[i];
                txtBoxI = txtListI[i];
                comboBoxU = cbListU[i];

                ingredient.ID = Convert.ToInt32(comboBoxI.SelectedValue);
                ingredient.amount = Convert.ToInt32(txtBoxI.Text);
                ingredient.unitID = Convert.ToInt32(comboBoxU.SelectedValue);

                ingredients.Add(ingredient);
            }

            int countS = pnlSteps.Controls.OfType<TextBox>().ToList().Count;
            lblListS = pnlStepNumber.Controls.OfType<Label>().ToList();
            txtListS = pnlSteps.Controls.OfType<TextBox>().ToList();

            for (int j = 0; j < countS; j++)
            {
                Step step = new Step();
                Label labelS = new Label();
                TextBox txtBoxS = new TextBox();

                labelS = lblListS[j];
                txtBoxS = txtListS[j];

                step.number = Convert.ToInt32(labelS.Text);
                step.description = txtBoxS.Text;

                steps.Add(step);
            }

            newRecipe.ingredients = ingredients;
            newRecipe.steps = steps;

            recipeService.insertRecipe(newRecipe);
        }

        private void btnAddNewIngredient_Click(object sender, EventArgs e)
        {
            var recipeService = new RecipeService();

            string newIngredient = Interaction.InputBox("Enter your new ingredient", "NewIngredient");
            recipeService.insertIngredient(newIngredient);
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
        /// <summary>
        /// Gets all data related to units and stores them in a datatable.
        /// </summary>
        /// <returns>DataTable</returns>
        private DataTable getUnitsTable()
        {
            DataTable unitsTable = new DataTable();
            SqlConnection connection;
            string connectionString = DatabaseFunctions.getConnectionString();

            //extract Units
            string queryU = "SELECT * FROM units";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryU, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(unitsTable);
            }

            return unitsTable;
        }

        private void AddNewRecipe_Load(object sender, EventArgs e)
        {
            cbIngredient1.ValueMember = "ID";
            cbIngredient1.DisplayMember = "ingredient";
            cbIngredient1.DataSource = getIngredientsTable();

            cbUnit1.ValueMember = "ID";
            cbUnit1.DisplayMember = "unit";
            cbUnit1.DataSource = getUnitsTable();
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            //Create the dynamic TextBox.
            TextBox textbox = new TextBox();
            ComboBox combobox1 = new ComboBox();
            ComboBox combobox2 = new ComboBox();
            int count = pnlAmount.Controls.OfType<TextBox>().ToList().Count;

            combobox1.Location = new System.Drawing.Point(0, (24 * count));
            combobox1.Size = new System.Drawing.Size(168, 21);
            combobox1.Name = "cbIngredient" + (count + 1);
            combobox1.ValueMember = "ID";
            combobox1.DisplayMember = "ingredient";
            combobox1.DataSource = getIngredientsTable();

            textbox.Location = new System.Drawing.Point(0, (24 * count));
            textbox.Size = new System.Drawing.Size(55, 21);
            textbox.Name = "txtAmount" + (count + 1);

            combobox2.Location = new System.Drawing.Point(0, (24 * count));
            combobox2.Size = new System.Drawing.Size(55, 21);
            combobox2.Name = "cbUnit" + (count + 1);
            combobox2.ValueMember = "ID";
            combobox2.DisplayMember = "unit";
            combobox2.DataSource = getUnitsTable();

            btnAddIngredient.Location = new System.Drawing.Point(28, 24 * (count + 1) + 48);

            pnlIngredients.Size = new System.Drawing.Size(179, 24 * (count + 1) + 7);
            pnlAmount.Size = new System.Drawing.Size(62, 24 * (count + 1) + 7);
            pnlUnit.Size = new System.Drawing.Size(62, 24 * (count + 1) + 7);

            pnlIngredients.Controls.Add(combobox1);
            pnlAmount.Controls.Add(textbox);
            pnlUnit.Controls.Add(combobox2);
        }

        private void btnAddStep_Click(object sender, EventArgs e)
        {
            //Create the dynamic TextBox.
            Label label = new Label();
            TextBox textbox = new TextBox();
            int count = pnlSteps.Controls.OfType<TextBox>().ToList().Count;

            label.Location = new System.Drawing.Point(0, (76 * count));
            label.Size = new System.Drawing.Size(15, 15);
            label.Name = "lblStepNumber" + (count + 1);
            label.Text = (count + 1) + ".";
            textbox.Location = new System.Drawing.Point(0, (76 * count));
            textbox.Size = new System.Drawing.Size(200, 66);
            textbox.Name = "txtStepDescription" + (count + 1);
            textbox.Multiline = true;

            btnAddStep.Location = new System.Drawing.Point(41, (76 * (count + 1)) + 48);

            pnlStepNumber.Size = new System.Drawing.Size(21, 76 * (count + 1) + 14);
            pnlSteps.Size = new System.Drawing.Size(213, 76 * (count + 1) + 14);

            pnlStepNumber.Controls.Add(label);
            pnlSteps.Controls.Add(textbox);
        }
    }
}

using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FoodApp
{
    public partial class AddNewRecipe : UserControl
    {
        DataTable ingredientsTable = new DataTable();
        DataTable unitsTable = new DataTable();
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

            for (int j = 0; j < countI; j++)
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

        

        private void AddNewRecipe_Load(object sender, EventArgs e)
        {
            SqlConnection connection;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\georg\OneDrive\Desktop\FoodApp\food-app_database.mdf;Integrated Security=True";

            //extrectIngredients
            string queryI = "SELECT * FROM ingredients";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryI, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(ingredientsTable);
            }

            //extrectUnits
            string queryU = "SELECT * FROM units";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(queryU, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(unitsTable);
            }

            cbIngredient1.ValueMember = "ID";
            cbIngredient1.DisplayMember = "ingredient";
            cbIngredient1.DataSource = ingredientsTable;

            cbUnit1.ValueMember = "ID";
            cbUnit1.DisplayMember = "unit";
            cbUnit1.DataSource = unitsTable;
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
                //Create the dynamic TextBox.
                TextBox textbox = new TextBox();
                ComboBox combobox1 = new ComboBox();
                ComboBox combobox2 = new ComboBox();
                int count = pnlAmount.Controls.OfType<TextBox>().ToList().Count;

                combobox1.Location = new System.Drawing.Point(0, (30 * count));
                combobox1.Size = new System.Drawing.Size(250, 28);
                combobox1.Name = "cbIngredient" + (count + 1);
                combobox1.ValueMember = "ID";
                combobox1.DisplayMember = "ingredient";
                combobox1.DataSource = ingredientsTable;

                textbox.Location = new System.Drawing.Point(0, (30 * count));
                textbox.Size = new System.Drawing.Size(80, 26);
                textbox.Name = "txtAmount" + (count + 1);

                combobox2.Location = new System.Drawing.Point(0, (30 * count));
                combobox2.Size = new System.Drawing.Size(80, 28);
                combobox2.Name = "cbUnit" + (count + 1);
                combobox2.ValueMember = "ID";
                combobox2.DisplayMember = "unit";
                combobox2.DataSource = unitsTable;

                btnAddIngredient.Location = new System.Drawing.Point(40, 30 * (count + 1) + 70);

                pnlIngredients.Size = new System.Drawing.Size(260, 30 * (count + 1) + 10);
                pnlAmount.Size = new System.Drawing.Size(90, 30 * (count + 1) + 10);
                pnlUnit.Size = new System.Drawing.Size(90, 30 * (count + 1) + 10);

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

            label.Location = new System.Drawing.Point(0, (110 * count));
            label.Size = new System.Drawing.Size(22, 22);
            label.Name = "lblStepNumber" + (count + 1);
            label.Text = (count + 1) + ".";
            textbox.Location = new System.Drawing.Point(0, (110 * count));
            textbox.Size = new System.Drawing.Size(211, 62);
            textbox.Name = "txtStepDescription" + (count + 1);
            textbox.Multiline = true;

            btnAddStep.Location = new System.Drawing.Point(60, (110 * (count + 1)) + 70);

            pnlStepNumber.Size = new System.Drawing.Size(30, 110 * (count + 1) + 20);
            pnlSteps.Size = new System.Drawing.Size(310, 110 * (count + 1) + 20);

            pnlStepNumber.Controls.Add(label);
            pnlSteps.Controls.Add(textbox);
        }
    }
}

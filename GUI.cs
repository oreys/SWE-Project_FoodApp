using System;
using System.Windows.Forms;

namespace FoodApp
{
    /// <summary>
    /// Is the main part of the app for user interaction.
    /// </summary>
    public partial class GUI : Form
    {

        public GUI()
        {
            InitializeComponent();
            Load += GUI_Load;
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            SetAvtivePanel(home1);
        }

        private void btnMenu_Click(object sender, EventArgs e) { }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            SetAvtivePanel(addNewRecipe1);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            SetAvtivePanel(home1);
        }

        private void btnSerchRecipe_Click(object sender, EventArgs e)
        {
            SetAvtivePanel(searchRecipe1);
        }

        /// <summary>
        /// 
        /// Sets the Active User Control and disables the other panels.
        /// 
        /// </summary>summary>
        /// <param name="control"></param>
        public void SetAvtivePanel(UserControl control)
        {
            // DISABLE ALL USEr CONTROLS //

            home1.Visible = false;
            searchRecipe1.Visible = false;
            addNewRecipe1.Visible = false;

            // ENABLE THE ACTIVE CONTROL //
            control.Visible = true;
        }
    }
}

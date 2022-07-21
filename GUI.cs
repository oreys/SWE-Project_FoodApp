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

        private void GUI_Load(object sender, EventArgs e)
        {
            SetAvtivePanel(home1);
        }

        private void btnMenu_Click(object sender, EventArgs e){ }

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

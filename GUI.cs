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
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (btnHome.Visible == false)
            {
                btnHome.Visible = true;
                btnSerchRecipe.Visible = true;
                btnAddRecipe.Visible = true;
            }
            else
            {
                btnHome.Visible = false;
                btnSerchRecipe.Visible = false;
                btnAddRecipe.Visible = false;
            }
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            //searchRecipe.Visible = false;
            addNewRecipe1.Visible = true;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            home1.Visible = true;
            //searchRecipe.Visible = false;
            addNewRecipe1.Visible = false;
        }

        private void btnSerchRecipe_Click(object sender, EventArgs e)
        {
            home1.Visible = false;
            //searchRecipe.Visible = true;
            addNewRecipe1.Visible = false;
        }
    }
}

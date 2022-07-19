using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}

namespace FoodApp
{
    partial class GUI
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnSerchRecipe = new System.Windows.Forms.Button();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.pnlSite = new System.Windows.Forms.Panel();
            this.pnlMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.Controls.Add(this.btnMenu);
            this.pnlMenu.Controls.Add(this.btnHome);
            this.pnlMenu.Controls.Add(this.btnSerchRecipe);
            this.pnlMenu.Controls.Add(this.btnAddRecipe);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 744);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnMenu
            // 
            this.btnMenu.Location = new System.Drawing.Point(12, 12);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(33, 33);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "≡";
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(25, 60);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(150, 33);
            this.btnHome.TabIndex = 2;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // btnSerchRecipe
            // 
            this.btnSerchRecipe.Location = new System.Drawing.Point(25, 120);
            this.btnSerchRecipe.Name = "btnSerchRecipe";
            this.btnSerchRecipe.Size = new System.Drawing.Size(150, 33);
            this.btnSerchRecipe.TabIndex = 3;
            this.btnSerchRecipe.Text = "Search Recipe";
            this.btnSerchRecipe.UseVisualStyleBackColor = true;
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(25, 180);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(150, 33);
            this.btnAddRecipe.TabIndex = 4;
            this.btnAddRecipe.Text = "Add Recipe";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            // 
            // pnlSite
            // 
            this.pnlSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSite.Location = new System.Drawing.Point(200, 0);
            this.pnlSite.Name = "pnlSite";
            this.pnlSite.Size = new System.Drawing.Size(978, 744);
            this.pnlSite.TabIndex = 1;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.pnlSite);
            this.Controls.Add(this.pnlMenu);
            this.Name = "GUI";
            this.Text = "Form1";
            this.pnlMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnSerchRecipe;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.Panel pnlSite;
    }
}


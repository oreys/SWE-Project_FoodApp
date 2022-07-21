namespace FoodApp
{
    partial class SearchRecipe
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbAddIngredient = new System.Windows.Forms.GroupBox();
            this.btnAddOtherIngredient = new System.Windows.Forms.Button();
            this.labelSelectIngredient = new System.Windows.Forms.Label();
            this.cbIngredient = new System.Windows.Forms.ComboBox();
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.labelEnteredIngredients = new System.Windows.Forms.Label();
            this.searchResults1 = new FoodApp.SearchResults();
            this.gbAddIngredient.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAddIngredient
            // 
            this.gbAddIngredient.Controls.Add(this.btnAddOtherIngredient);
            this.gbAddIngredient.Controls.Add(this.labelSelectIngredient);
            this.gbAddIngredient.Controls.Add(this.cbIngredient);
            this.gbAddIngredient.Location = new System.Drawing.Point(68, 25);
            this.gbAddIngredient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbAddIngredient.Name = "gbAddIngredient";
            this.gbAddIngredient.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbAddIngredient.Size = new System.Drawing.Size(962, 152);
            this.gbAddIngredient.TabIndex = 0;
            this.gbAddIngredient.TabStop = false;
            this.gbAddIngredient.Text = "groupBox1";
            // 
            // btnAddOtherIngredient
            // 
            this.btnAddOtherIngredient.Location = new System.Drawing.Point(696, 98);
            this.btnAddOtherIngredient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddOtherIngredient.Name = "btnAddOtherIngredient";
            this.btnAddOtherIngredient.Size = new System.Drawing.Size(207, 29);
            this.btnAddOtherIngredient.TabIndex = 2;
            this.btnAddOtherIngredient.Text = "Add Another Ingredient";
            this.btnAddOtherIngredient.UseVisualStyleBackColor = true;
            this.btnAddOtherIngredient.Click += new System.EventHandler(this.btnAddOtherIngredient_Click);
            // 
            // labelSelectIngredient
            // 
            this.labelSelectIngredient.AutoSize = true;
            this.labelSelectIngredient.Location = new System.Drawing.Point(138, 54);
            this.labelSelectIngredient.Name = "labelSelectIngredient";
            this.labelSelectIngredient.Size = new System.Drawing.Size(138, 20);
            this.labelSelectIngredient.TabIndex = 1;
            this.labelSelectIngredient.Text = "Select Ingredient :";
            // 
            // cbIngredient
            // 
            this.cbIngredient.FormattingEnabled = true;
            this.cbIngredient.Location = new System.Drawing.Point(297, 50);
            this.cbIngredient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbIngredient.Name = "cbIngredient";
            this.cbIngredient.Size = new System.Drawing.Size(335, 28);
            this.cbIngredient.TabIndex = 0;
            this.cbIngredient.SelectedIndexChanged += new System.EventHandler(this.cbIngredient_SelectedIndexChanged);
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(793, 202);
            this.btnStartSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(178, 29);
            this.btnStartSearch.TabIndex = 1;
            this.btnStartSearch.Text = "Search For Recipes";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_Click);
            // 
            // labelEnteredIngredients
            // 
            this.labelEnteredIngredients.AutoSize = true;
            this.labelEnteredIngredients.Location = new System.Drawing.Point(133, 269);
            this.labelEnteredIngredients.Name = "labelEnteredIngredients";
            this.labelEnteredIngredients.Size = new System.Drawing.Size(51, 20);
            this.labelEnteredIngredients.TabIndex = 2;
            this.labelEnteredIngredients.Text = "label1";
            // 
            // searchResults1
            // 
            this.searchResults1.Location = new System.Drawing.Point(0, 0);
            this.searchResults1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.searchResults1.Name = "searchResults1";
            this.searchResults1.Size = new System.Drawing.Size(1105, 941);
            this.searchResults1.TabIndex = 3;
            // 
            // SearchRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchResults1);
            this.Controls.Add(this.labelEnteredIngredients);
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.gbAddIngredient);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SearchRecipe";
            this.Size = new System.Drawing.Size(1105, 941);
            this.gbAddIngredient.ResumeLayout(false);
            this.gbAddIngredient.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbAddIngredient;
        private System.Windows.Forms.Button btnAddOtherIngredient;
        private System.Windows.Forms.Label labelSelectIngredient;
        private System.Windows.Forms.ComboBox cbIngredient;
        private System.Windows.Forms.Button btnStartSearch;
        private System.Windows.Forms.Label labelEnteredIngredients;
        private SearchResults searchResults1;
    }
}

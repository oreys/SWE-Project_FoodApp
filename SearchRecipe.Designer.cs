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
            this.btnStartSearch = new System.Windows.Forms.Button();
            this.btnAddOtherIngredient = new System.Windows.Forms.Button();
            this.cbIngredient = new System.Windows.Forms.ComboBox();
            this.labelSelectIngredient = new System.Windows.Forms.Label();
            this.pnlIngredient = new System.Windows.Forms.Panel();
            this.searchResults1 = new FoodApp.SearchResults();
            this.pnlIngredient.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartSearch
            // 
            this.btnStartSearch.Location = new System.Drawing.Point(570, 33);
            this.btnStartSearch.Name = "btnStartSearch";
            this.btnStartSearch.Size = new System.Drawing.Size(158, 23);
            this.btnStartSearch.TabIndex = 1;
            this.btnStartSearch.Text = "Search For Recipes";
            this.btnStartSearch.UseVisualStyleBackColor = true;
            this.btnStartSearch.Click += new System.EventHandler(this.btnStartSearch_Click);
            // 
            // btnAddOtherIngredient
            // 
            this.btnAddOtherIngredient.Location = new System.Drawing.Point(570, 56);
            this.btnAddOtherIngredient.Name = "btnAddOtherIngredient";
            this.btnAddOtherIngredient.Size = new System.Drawing.Size(184, 23);
            this.btnAddOtherIngredient.TabIndex = 2;
            this.btnAddOtherIngredient.Text = "Add Another Ingredient";
            this.btnAddOtherIngredient.UseVisualStyleBackColor = true;
            this.btnAddOtherIngredient.Click += new System.EventHandler(this.btnAddOtherIngredient_Click);
            // 
            // cbIngredient
            // 
            this.cbIngredient.FormattingEnabled = true;
            this.cbIngredient.Location = new System.Drawing.Point(21, 7);
            this.cbIngredient.Name = "cbIngredient";
            this.cbIngredient.Size = new System.Drawing.Size(298, 24);
            this.cbIngredient.TabIndex = 0;
            this.cbIngredient.SelectedIndexChanged += new System.EventHandler(this.cbIngredient_SelectedIndexChanged);
            // 
            // labelSelectIngredient
            // 
            this.labelSelectIngredient.AutoSize = true;
            this.labelSelectIngredient.Location = new System.Drawing.Point(41, 39);
            this.labelSelectIngredient.Name = "labelSelectIngredient";
            this.labelSelectIngredient.Size = new System.Drawing.Size(120, 16);
            this.labelSelectIngredient.TabIndex = 1;
            this.labelSelectIngredient.Text = "Select Ingredients :";
            // 
            // pnlIngredient
            // 
            this.pnlIngredient.Controls.Add(this.cbIngredient);
            this.pnlIngredient.Location = new System.Drawing.Point(164, 33);
            this.pnlIngredient.Name = "pnlIngredient";
            this.pnlIngredient.Size = new System.Drawing.Size(338, 38);
            this.pnlIngredient.TabIndex = 4;
            // 
            // searchResults1
            // 
            this.searchResults1.Location = new System.Drawing.Point(0, 0);
            this.searchResults1.Name = "searchResults1";
            this.searchResults1.Size = new System.Drawing.Size(869, 595);
            this.searchResults1.TabIndex = 3;
            this.searchResults1.Load += new System.EventHandler(this.searchResults1_Load);
            // 
            // SearchRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.searchResults1);
            this.Controls.Add(this.labelSelectIngredient);
            this.Controls.Add(this.btnAddOtherIngredient);
            this.Controls.Add(this.btnStartSearch);
            this.Controls.Add(this.pnlIngredient);
            this.Name = "SearchRecipe";
            this.Size = new System.Drawing.Size(869, 595);
            this.pnlIngredient.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStartSearch;
        private SearchResults searchResults1;
        private System.Windows.Forms.Button btnAddOtherIngredient;
        private System.Windows.Forms.Label labelSelectIngredient;
        private System.Windows.Forms.ComboBox cbIngredient;
        private System.Windows.Forms.Panel pnlIngredient;
    }
}

namespace FoodApp
{
    partial class SearchResults
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
            this.gbRecipe = new System.Windows.Forms.GroupBox();
            this.labelRecipeDescription = new System.Windows.Forms.Label();
            this.labelRecipeName = new System.Windows.Forms.Label();
            this.flowPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.gbRecipe.SuspendLayout();
            this.flowPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbRecipe
            // 
            this.gbRecipe.Controls.Add(this.labelRecipeDescription);
            this.gbRecipe.Controls.Add(this.labelRecipeName);
            this.gbRecipe.Location = new System.Drawing.Point(3, 3);
            this.gbRecipe.Name = "gbRecipe";
            this.gbRecipe.Size = new System.Drawing.Size(841, 140);
            this.gbRecipe.TabIndex = 0;
            this.gbRecipe.TabStop = false;
            this.gbRecipe.Text = "groupBox1";
            this.gbRecipe.Enter += new System.EventHandler(this.gbRecipe_Enter);
            // 
            // labelRecipeDescription
            // 
            this.labelRecipeDescription.AutoSize = true;
            this.labelRecipeDescription.Location = new System.Drawing.Point(189, 53);
            this.labelRecipeDescription.Name = "labelRecipeDescription";
            this.labelRecipeDescription.Size = new System.Drawing.Size(44, 16);
            this.labelRecipeDescription.TabIndex = 1;
            this.labelRecipeDescription.Text = "label1";
            // 
            // labelRecipeName
            // 
            this.labelRecipeName.AutoSize = true;
            this.labelRecipeName.Location = new System.Drawing.Point(45, 53);
            this.labelRecipeName.Name = "labelRecipeName";
            this.labelRecipeName.Size = new System.Drawing.Size(44, 16);
            this.labelRecipeName.TabIndex = 0;
            this.labelRecipeName.Text = "label1";
            // 
            // flowPnl
            // 
            this.flowPnl.Controls.Add(this.gbRecipe);
            this.flowPnl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPnl.Location = new System.Drawing.Point(67, 57);
            this.flowPnl.Name = "flowPnl";
            this.flowPnl.Size = new System.Drawing.Size(847, 664);
            this.flowPnl.TabIndex = 1;
            // 
            // SearchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPnl);
            this.Name = "SearchResults";
            this.Size = new System.Drawing.Size(982, 753);
            this.gbRecipe.ResumeLayout(false);
            this.gbRecipe.PerformLayout();
            this.flowPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbRecipe;
        private System.Windows.Forms.Label labelRecipeDescription;
        private System.Windows.Forms.Label labelRecipeName;
        private System.Windows.Forms.FlowLayoutPanel flowPnl;
    }
}

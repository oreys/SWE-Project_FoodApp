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
            this.flowPnl = new System.Windows.Forms.FlowLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.showRecipe1 = new FoodApp.ShowRecipe();
            this.SuspendLayout();
            // 
            // flowPnl
            // 
            this.flowPnl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPnl.Location = new System.Drawing.Point(26, 40);
            this.flowPnl.Name = "flowPnl";
            this.flowPnl.Size = new System.Drawing.Size(812, 535);
            this.flowPnl.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(26, 11);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // showRecipe1
            // 
            this.showRecipe1.Location = new System.Drawing.Point(0, 0);
            this.showRecipe1.Name = "showRecipe1";
            this.showRecipe1.Size = new System.Drawing.Size(869, 595);
            this.showRecipe1.TabIndex = 3;
            this.showRecipe1.Visible = false;
            // 
            // SearchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.showRecipe1);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.flowPnl);
            this.Name = "SearchResults";
            this.Size = new System.Drawing.Size(869, 595);
            this.Load += new System.EventHandler(this.SearchResults_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowPnl;
        private System.Windows.Forms.Button btnBack;
        private ShowRecipe showRecipe1;
    }
}

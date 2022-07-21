namespace FoodApp
{
    partial class ShowRecipe
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
            this.flowPnlShowRecipe = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowPnlShowRecipe
            // 
            this.flowPnlShowRecipe.Location = new System.Drawing.Point(21, 16);
            this.flowPnlShowRecipe.Name = "flowPnlShowRecipe";
            this.flowPnlShowRecipe.Size = new System.Drawing.Size(825, 564);
            this.flowPnlShowRecipe.TabIndex = 0;
            // 
            // ShowRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPnlShowRecipe);
            this.Name = "ShowRecipe";
            this.Size = new System.Drawing.Size(869, 595);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowPnlShowRecipe;
    }
}

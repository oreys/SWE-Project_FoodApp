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
            this.SuspendLayout();
            // 
            // flowPnl
            // 
            this.flowPnl.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPnl.Location = new System.Drawing.Point(26, 18);
            this.flowPnl.Name = "flowPnl";
            this.flowPnl.Size = new System.Drawing.Size(812, 557);
            this.flowPnl.TabIndex = 1;
            // 
            // SearchResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowPnl);
            this.Name = "SearchResults";
            this.Size = new System.Drawing.Size(869, 595);
            this.Load += new System.EventHandler(this.SearchResults_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flowPnl;
    }
}

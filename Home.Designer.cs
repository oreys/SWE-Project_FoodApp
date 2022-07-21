namespace FoodApp
{
    partial class Home
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
            this.lblHomeText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHomeText
            // 
            this.lblHomeText.AutoSize = true;
            this.lblHomeText.Location = new System.Drawing.Point(394, 229);
            this.lblHomeText.Name = "lblHomeText";
            this.lblHomeText.Size = new System.Drawing.Size(163, 20);
            this.lblHomeText.TabIndex = 0;
            this.lblHomeText.Text = "Welcome to FoodApp";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHomeText);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(978, 744);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHomeText;
    }
}

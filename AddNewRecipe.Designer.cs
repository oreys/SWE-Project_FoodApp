namespace FoodApp
{
    partial class AddNewRecipe
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
            this.pnlHead = new System.Windows.Forms.Panel();
            this.btnAddNewIngredient = new System.Windows.Forms.Button();
            this.txtNewRecipeName = new System.Windows.Forms.TextBox();
            this.txtNewRecipeDescription = new System.Windows.Forms.TextBox();
            this.lblNewRecipeName = new System.Windows.Forms.Label();
            this.lblNewRecipeDescription = new System.Windows.Forms.Label();
            this.btnAddNewRecipe = new System.Windows.Forms.Button();
            this.pnlIngredientsCombined = new System.Windows.Forms.Panel();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.pnlIngredients = new System.Windows.Forms.Panel();
            this.cbIngredient1 = new System.Windows.Forms.ComboBox();
            this.pnlAmount = new System.Windows.Forms.Panel();
            this.txtAmount1 = new System.Windows.Forms.TextBox();
            this.pnlUnit = new System.Windows.Forms.Panel();
            this.cbUnit1 = new System.Windows.Forms.ComboBox();
            this.lblIngregient = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.pnlStepsCombined = new System.Windows.Forms.Panel();
            this.btnAddStep = new System.Windows.Forms.Button();
            this.pnlSteps = new System.Windows.Forms.Panel();
            this.txtStepDescription1 = new System.Windows.Forms.TextBox();
            this.pnlStepNumber = new System.Windows.Forms.Panel();
            this.lblStepNumber1 = new System.Windows.Forms.Label();
            this.lblSteps = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.pnlHead.SuspendLayout();
            this.pnlIngredientsCombined.SuspendLayout();
            this.pnlIngredients.SuspendLayout();
            this.pnlAmount.SuspendLayout();
            this.pnlUnit.SuspendLayout();
            this.pnlStepsCombined.SuspendLayout();
            this.pnlSteps.SuspendLayout();
            this.pnlStepNumber.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHead
            // 
            this.pnlHead.Controls.Add(this.btnAddNewIngredient);
            this.pnlHead.Controls.Add(this.txtNewRecipeName);
            this.pnlHead.Controls.Add(this.txtNewRecipeDescription);
            this.pnlHead.Controls.Add(this.lblNewRecipeName);
            this.pnlHead.Controls.Add(this.lblNewRecipeDescription);
            this.pnlHead.Controls.Add(this.btnAddNewRecipe);
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(978, 250);
            this.pnlHead.TabIndex = 0;
            // 
            // btnAddNewIngredient
            // 
            this.btnAddNewIngredient.Location = new System.Drawing.Point(660, 140);
            this.btnAddNewIngredient.Name = "btnAddNewIngredient";
            this.btnAddNewIngredient.Size = new System.Drawing.Size(181, 33);
            this.btnAddNewIngredient.TabIndex = 11;
            this.btnAddNewIngredient.Text = "Add New Ingredient";
            this.btnAddNewIngredient.UseVisualStyleBackColor = true;
            this.btnAddNewIngredient.Click += new System.EventHandler(this.btnAddNewIngredient_Click);
            // 
            // txtNewRecipeName
            // 
            this.txtNewRecipeName.Location = new System.Drawing.Point(60, 45);
            this.txtNewRecipeName.Name = "txtNewRecipeName";
            this.txtNewRecipeName.Size = new System.Drawing.Size(100, 26);
            this.txtNewRecipeName.TabIndex = 10;
            // 
            // txtNewRecipeDescription
            // 
            this.txtNewRecipeDescription.Location = new System.Drawing.Point(60, 105);
            this.txtNewRecipeDescription.Multiline = true;
            this.txtNewRecipeDescription.Name = "txtNewRecipeDescription";
            this.txtNewRecipeDescription.Size = new System.Drawing.Size(300, 100);
            this.txtNewRecipeDescription.TabIndex = 9;
            // 
            // lblNewRecipeName
            // 
            this.lblNewRecipeName.AutoSize = true;
            this.lblNewRecipeName.Location = new System.Drawing.Point(60, 20);
            this.lblNewRecipeName.Name = "lblNewRecipeName";
            this.lblNewRecipeName.Size = new System.Drawing.Size(140, 20);
            this.lblNewRecipeName.TabIndex = 2;
            this.lblNewRecipeName.Text = "New Recipe Name";
            // 
            // lblNewRecipeDescription
            // 
            this.lblNewRecipeDescription.AutoSize = true;
            this.lblNewRecipeDescription.Location = new System.Drawing.Point(60, 80);
            this.lblNewRecipeDescription.Name = "lblNewRecipeDescription";
            this.lblNewRecipeDescription.Size = new System.Drawing.Size(143, 20);
            this.lblNewRecipeDescription.TabIndex = 1;
            this.lblNewRecipeDescription.Text = "Recipe Description";
            // 
            // btnAddNewRecipe
            // 
            this.btnAddNewRecipe.Location = new System.Drawing.Point(660, 80);
            this.btnAddNewRecipe.Name = "btnAddNewRecipe";
            this.btnAddNewRecipe.Size = new System.Drawing.Size(181, 33);
            this.btnAddNewRecipe.TabIndex = 0;
            this.btnAddNewRecipe.Text = "Add New Recipe";
            this.btnAddNewRecipe.UseVisualStyleBackColor = true;
            this.btnAddNewRecipe.Click += new System.EventHandler(this.btnAddNewRecipe_Click);
            // 
            // pnlIngredientsCombined
            // 
            this.pnlIngredientsCombined.Controls.Add(this.btnAddIngredient);
            this.pnlIngredientsCombined.Controls.Add(this.pnlIngredients);
            this.pnlIngredientsCombined.Controls.Add(this.pnlAmount);
            this.pnlIngredientsCombined.Controls.Add(this.pnlUnit);
            this.pnlIngredientsCombined.Controls.Add(this.lblIngregient);
            this.pnlIngredientsCombined.Controls.Add(this.lblUnit);
            this.pnlIngredientsCombined.Controls.Add(this.lblAmount);
            this.pnlIngredientsCombined.Location = new System.Drawing.Point(0, 250);
            this.pnlIngredientsCombined.Name = "pnlIngredientsCombined";
            this.pnlIngredientsCombined.Size = new System.Drawing.Size(580, 494);
            this.pnlIngredientsCombined.TabIndex = 0;
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.Location = new System.Drawing.Point(40, 100);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(150, 33);
            this.btnAddIngredient.TabIndex = 2;
            this.btnAddIngredient.Text = "Add Ingredient";
            this.btnAddIngredient.UseVisualStyleBackColor = true;
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // pnlIngredients
            // 
            this.pnlIngredients.Controls.Add(this.cbIngredient1);
            this.pnlIngredients.Location = new System.Drawing.Point(20, 50);
            this.pnlIngredients.Name = "pnlIngredients";
            this.pnlIngredients.Size = new System.Drawing.Size(260, 40);
            this.pnlIngredients.TabIndex = 0;
            // 
            // cbIngredient1
            // 
            this.cbIngredient1.FormattingEnabled = true;
            this.cbIngredient1.Location = new System.Drawing.Point(0, 0);
            this.cbIngredient1.Name = "cbIngredient1";
            this.cbIngredient1.Size = new System.Drawing.Size(250, 28);
            this.cbIngredient1.TabIndex = 13;
            // 
            // pnlAmount
            // 
            this.pnlAmount.Controls.Add(this.txtAmount1);
            this.pnlAmount.Location = new System.Drawing.Point(300, 50);
            this.pnlAmount.Name = "pnlAmount";
            this.pnlAmount.Size = new System.Drawing.Size(90, 40);
            this.pnlAmount.TabIndex = 0;
            // 
            // txtAmount1
            // 
            this.txtAmount1.Location = new System.Drawing.Point(0, 0);
            this.txtAmount1.Name = "txtAmount1";
            this.txtAmount1.Size = new System.Drawing.Size(80, 26);
            this.txtAmount1.TabIndex = 7;
            // 
            // pnlUnit
            // 
            this.pnlUnit.Controls.Add(this.cbUnit1);
            this.pnlUnit.Location = new System.Drawing.Point(400, 50);
            this.pnlUnit.Name = "pnlUnit";
            this.pnlUnit.Size = new System.Drawing.Size(90, 40);
            this.pnlUnit.TabIndex = 14;
            // 
            // cbUnit1
            // 
            this.cbUnit1.FormattingEnabled = true;
            this.cbUnit1.Location = new System.Drawing.Point(0, 0);
            this.cbUnit1.Name = "cbUnit1";
            this.cbUnit1.Size = new System.Drawing.Size(80, 28);
            this.cbUnit1.TabIndex = 12;
            // 
            // lblIngregient
            // 
            this.lblIngregient.AutoSize = true;
            this.lblIngregient.Location = new System.Drawing.Point(20, 20);
            this.lblIngregient.Name = "lblIngregient";
            this.lblIngregient.Size = new System.Drawing.Size(81, 20);
            this.lblIngregient.TabIndex = 5;
            this.lblIngregient.Text = "Ingregient";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(400, 20);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(38, 20);
            this.lblUnit.TabIndex = 3;
            this.lblUnit.Text = "Unit";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(300, 20);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(65, 20);
            this.lblAmount.TabIndex = 4;
            this.lblAmount.Text = "Amount";
            // 
            // pnlStepsCombined
            // 
            this.pnlStepsCombined.Controls.Add(this.btnAddStep);
            this.pnlStepsCombined.Controls.Add(this.pnlSteps);
            this.pnlStepsCombined.Controls.Add(this.pnlStepNumber);
            this.pnlStepsCombined.Controls.Add(this.lblSteps);
            this.pnlStepsCombined.Location = new System.Drawing.Point(580, 250);
            this.pnlStepsCombined.Name = "pnlStepsCombined";
            this.pnlStepsCombined.Size = new System.Drawing.Size(398, 494);
            this.pnlStepsCombined.TabIndex = 0;
            // 
            // btnAddStep
            // 
            this.btnAddStep.Location = new System.Drawing.Point(60, 180);
            this.btnAddStep.Name = "btnAddStep";
            this.btnAddStep.Size = new System.Drawing.Size(150, 33);
            this.btnAddStep.TabIndex = 1;
            this.btnAddStep.Text = "Add Step";
            this.btnAddStep.UseVisualStyleBackColor = true;
            this.btnAddStep.Click += new System.EventHandler(this.btnAddStep_Click);
            // 
            // pnlSteps
            // 
            this.pnlSteps.Controls.Add(this.txtStepDescription1);
            this.pnlSteps.Location = new System.Drawing.Point(60, 50);
            this.pnlSteps.Name = "pnlSteps";
            this.pnlSteps.Size = new System.Drawing.Size(310, 120);
            this.pnlSteps.TabIndex = 13;
            // 
            // txtStepDescription1
            // 
            this.txtStepDescription1.Location = new System.Drawing.Point(0, 0);
            this.txtStepDescription1.Multiline = true;
            this.txtStepDescription1.Name = "txtStepDescription1";
            this.txtStepDescription1.Size = new System.Drawing.Size(300, 100);
            this.txtStepDescription1.TabIndex = 8;
            // 
            // pnlStepNumber
            // 
            this.pnlStepNumber.Controls.Add(this.lblStepNumber1);
            this.pnlStepNumber.Location = new System.Drawing.Point(25, 50);
            this.pnlStepNumber.Name = "pnlStepNumber";
            this.pnlStepNumber.Size = new System.Drawing.Size(30, 120);
            this.pnlStepNumber.TabIndex = 12;
            // 
            // lblStepNumber1
            // 
            this.lblStepNumber1.AutoSize = true;
            this.lblStepNumber1.Location = new System.Drawing.Point(0, 0);
            this.lblStepNumber1.Name = "lblStepNumber1";
            this.lblStepNumber1.Size = new System.Drawing.Size(22, 20);
            this.lblStepNumber1.TabIndex = 6;
            this.lblStepNumber1.Text = "1.";
            // 
            // lblSteps
            // 
            this.lblSteps.AutoSize = true;
            this.lblSteps.Location = new System.Drawing.Point(60, 20);
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.Size = new System.Drawing.Size(51, 20);
            this.lblSteps.TabIndex = 11;
            this.lblSteps.Text = "Steps";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(952, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(26, 744);
            this.vScrollBar1.TabIndex = 1;
            // 
            // AddNewRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.pnlIngredientsCombined);
            this.Controls.Add(this.pnlStepsCombined);
            this.Controls.Add(this.pnlHead);
            this.Name = "AddNewRecipe";
            this.Size = new System.Drawing.Size(978, 744);
            this.Load += new System.EventHandler(this.AddNewRecipe_Load);
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.pnlIngredientsCombined.ResumeLayout(false);
            this.pnlIngredientsCombined.PerformLayout();
            this.pnlIngredients.ResumeLayout(false);
            this.pnlAmount.ResumeLayout(false);
            this.pnlAmount.PerformLayout();
            this.pnlUnit.ResumeLayout(false);
            this.pnlStepsCombined.ResumeLayout(false);
            this.pnlStepsCombined.PerformLayout();
            this.pnlSteps.ResumeLayout(false);
            this.pnlSteps.PerformLayout();
            this.pnlStepNumber.ResumeLayout(false);
            this.pnlStepNumber.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Panel pnlIngredientsCombined;
        private System.Windows.Forms.Panel pnlStepsCombined;
        private System.Windows.Forms.Button btnAddNewRecipe;
        private System.Windows.Forms.TextBox txtNewRecipeName;
        private System.Windows.Forms.TextBox txtNewRecipeDescription;
        private System.Windows.Forms.Label lblNewRecipeName;
        private System.Windows.Forms.Label lblNewRecipeDescription;
        private System.Windows.Forms.TextBox txtAmount1;
        private System.Windows.Forms.Label lblIngregient;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtStepDescription1;
        private System.Windows.Forms.Label lblStepNumber1;
        private System.Windows.Forms.Label lblSteps;
        private System.Windows.Forms.ComboBox cbUnit1;
        private System.Windows.Forms.ComboBox cbIngredient1;
        private System.Windows.Forms.Panel pnlIngredients;
        private System.Windows.Forms.Panel pnlAmount;
        private System.Windows.Forms.Panel pnlUnit;
        private System.Windows.Forms.Panel pnlStepNumber;
        private System.Windows.Forms.Panel pnlSteps;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.Button btnAddStep;
        private System.Windows.Forms.Button btnAddNewIngredient;
        private System.Windows.Forms.VScrollBar vScrollBar1;
    }
}

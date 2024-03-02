namespace GraphicalCalculator
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.graphButton = new System.Windows.Forms.Button();
            this.functionBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // graphButton
            // 
            this.graphButton.Location = new System.Drawing.Point(294, 211);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(208, 129);
            this.graphButton.TabIndex = 0;
            this.graphButton.Text = "button1";
            this.graphButton.UseVisualStyleBackColor = true;
            this.graphButton.Click += new System.EventHandler(this.graphButton_Click);
            // 
            // functionBox
            // 
            this.functionBox.Location = new System.Drawing.Point(294, 109);
            this.functionBox.Name = "functionBox";
            this.functionBox.Size = new System.Drawing.Size(208, 23);
            this.functionBox.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.functionBox);
            this.Controls.Add(this.graphButton);
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button graphButton;
        private System.Windows.Forms.TextBox functionBox;
    }
}
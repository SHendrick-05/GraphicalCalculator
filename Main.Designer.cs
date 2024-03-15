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
            this.functionLabel = new System.Windows.Forms.Label();
            this.topPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.minXBox = new System.Windows.Forms.TextBox();
            this.maxXBox = new System.Windows.Forms.TextBox();
            this.minXLabel = new System.Windows.Forms.Label();
            this.maxXLabel = new System.Windows.Forms.Label();
            this.maxYLabel = new System.Windows.Forms.Label();
            this.minYLabel = new System.Windows.Forms.Label();
            this.maxYBox = new System.Windows.Forms.TextBox();
            this.minYBox = new System.Windows.Forms.TextBox();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // graphButton
            // 
            this.graphButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.graphButton.Font = new System.Drawing.Font("Lucida Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.graphButton.ForeColor = System.Drawing.SystemColors.Control;
            this.graphButton.Location = new System.Drawing.Point(18, 274);
            this.graphButton.Name = "graphButton";
            this.graphButton.Size = new System.Drawing.Size(375, 36);
            this.graphButton.TabIndex = 0;
            this.graphButton.Text = "Plot graph";
            this.graphButton.UseVisualStyleBackColor = true;
            this.graphButton.Click += new System.EventHandler(this.graphButton_Click);
            // 
            // functionBox
            // 
            this.functionBox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.functionBox.Location = new System.Drawing.Point(67, 89);
            this.functionBox.Name = "functionBox";
            this.functionBox.Size = new System.Drawing.Size(326, 26);
            this.functionBox.TabIndex = 1;
            // 
            // functionLabel
            // 
            this.functionLabel.AutoSize = true;
            this.functionLabel.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.functionLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.functionLabel.Location = new System.Drawing.Point(18, 89);
            this.functionLabel.Name = "functionLabel";
            this.functionLabel.Size = new System.Drawing.Size(43, 22);
            this.functionLabel.TabIndex = 2;
            this.functionLabel.Text = "y = ";
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(41)))));
            this.topPanel.Controls.Add(this.closeButton);
            this.topPanel.Controls.Add(this.titleLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(445, 50);
            this.topPanel.TabIndex = 3;
            // 
            // closeButton
            // 
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Lucida Sans", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.closeButton.Location = new System.Drawing.Point(343, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(102, 50);
            this.closeButton.TabIndex = 4;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.titleLabel.Location = new System.Drawing.Point(12, 18);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(265, 22);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Mathematical graph plotter";
            // 
            // minXBox
            // 
            this.minXBox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minXBox.Location = new System.Drawing.Point(86, 185);
            this.minXBox.Name = "minXBox";
            this.minXBox.Size = new System.Drawing.Size(110, 26);
            this.minXBox.TabIndex = 4;
            this.minXBox.Text = "-5";
            // 
            // maxXBox
            // 
            this.maxXBox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxXBox.Location = new System.Drawing.Point(86, 216);
            this.maxXBox.Name = "maxXBox";
            this.maxXBox.Size = new System.Drawing.Size(110, 26);
            this.maxXBox.TabIndex = 5;
            this.maxXBox.Text = "5";
            // 
            // minXLabel
            // 
            this.minXLabel.AutoSize = true;
            this.minXLabel.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minXLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.minXLabel.Location = new System.Drawing.Point(18, 185);
            this.minXLabel.Name = "minXLabel";
            this.minXLabel.Size = new System.Drawing.Size(62, 22);
            this.minXLabel.TabIndex = 6;
            this.minXLabel.Text = "Min X";
            // 
            // maxXLabel
            // 
            this.maxXLabel.AutoSize = true;
            this.maxXLabel.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxXLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.maxXLabel.Location = new System.Drawing.Point(18, 217);
            this.maxXLabel.Name = "maxXLabel";
            this.maxXLabel.Size = new System.Drawing.Size(66, 22);
            this.maxXLabel.TabIndex = 7;
            this.maxXLabel.Text = "Max X";
            // 
            // maxYLabel
            // 
            this.maxYLabel.AutoSize = true;
            this.maxYLabel.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxYLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.maxYLabel.Location = new System.Drawing.Point(215, 217);
            this.maxYLabel.Name = "maxYLabel";
            this.maxYLabel.Size = new System.Drawing.Size(67, 22);
            this.maxYLabel.TabIndex = 11;
            this.maxYLabel.Text = "Max Y";
            // 
            // minYLabel
            // 
            this.minYLabel.AutoSize = true;
            this.minYLabel.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minYLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.minYLabel.Location = new System.Drawing.Point(215, 185);
            this.minYLabel.Name = "minYLabel";
            this.minYLabel.Size = new System.Drawing.Size(63, 22);
            this.minYLabel.TabIndex = 10;
            this.minYLabel.Text = "Min Y";
            // 
            // maxYBox
            // 
            this.maxYBox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxYBox.Location = new System.Drawing.Point(283, 216);
            this.maxYBox.Name = "maxYBox";
            this.maxYBox.Size = new System.Drawing.Size(110, 26);
            this.maxYBox.TabIndex = 9;
            this.maxYBox.Text = "5";
            // 
            // minYBox
            // 
            this.minYBox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minYBox.Location = new System.Drawing.Point(283, 185);
            this.minYBox.Name = "minYBox";
            this.minYBox.Size = new System.Drawing.Size(110, 26);
            this.minYBox.TabIndex = 8;
            this.minYBox.Text = "-5";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(445, 365);
            this.Controls.Add(this.maxYLabel);
            this.Controls.Add(this.minYLabel);
            this.Controls.Add(this.maxYBox);
            this.Controls.Add(this.minYBox);
            this.Controls.Add(this.maxXLabel);
            this.Controls.Add(this.minXLabel);
            this.Controls.Add(this.maxXBox);
            this.Controls.Add(this.minXBox);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.functionLabel);
            this.Controls.Add(this.functionBox);
            this.Controls.Add(this.graphButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.Text = "Main";
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button graphButton;
        private System.Windows.Forms.TextBox functionBox;
        private System.Windows.Forms.Label functionLabel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox minXBox;
        private System.Windows.Forms.TextBox maxXBox;
        private System.Windows.Forms.Label minXLabel;
        private System.Windows.Forms.Label maxXLabel;
        private System.Windows.Forms.Label maxYLabel;
        private System.Windows.Forms.Label minYLabel;
        private System.Windows.Forms.TextBox maxYBox;
        private System.Windows.Forms.TextBox minYBox;
    }
}
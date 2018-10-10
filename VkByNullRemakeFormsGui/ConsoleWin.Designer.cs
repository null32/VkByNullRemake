namespace VkByNullRemakeFormsGui
{
    partial class ConsoleWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsoleWin));
            this.MainRTB = new System.Windows.Forms.RichTextBox();
            this.SumbitTextBox = new System.Windows.Forms.TextBox();
            this.SumbitBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MainRTB
            // 
            this.MainRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainRTB.Location = new System.Drawing.Point(12, 12);
            this.MainRTB.Margin = new System.Windows.Forms.Padding(3, 3, 3, 30);
            this.MainRTB.Name = "MainRTB";
            this.MainRTB.ReadOnly = true;
            this.MainRTB.Size = new System.Drawing.Size(268, 222);
            this.MainRTB.TabIndex = 0;
            this.MainRTB.Text = "";
            // 
            // SumbitTextBox
            // 
            this.SumbitTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SumbitTextBox.Location = new System.Drawing.Point(12, 240);
            this.SumbitTextBox.Name = "SumbitTextBox";
            this.SumbitTextBox.Size = new System.Drawing.Size(187, 20);
            this.SumbitTextBox.TabIndex = 1;
            // 
            // SumbitBtn
            // 
            this.SumbitBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SumbitBtn.Location = new System.Drawing.Point(205, 238);
            this.SumbitBtn.Name = "SumbitBtn";
            this.SumbitBtn.Size = new System.Drawing.Size(75, 23);
            this.SumbitBtn.TabIndex = 2;
            this.SumbitBtn.Text = "Sumbit";
            this.SumbitBtn.UseVisualStyleBackColor = true;
            this.SumbitBtn.Click += new System.EventHandler(this.SumbitBtn_Click);
            // 
            // ConsoleWin
            // 
            this.AcceptButton = this.SumbitBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.SumbitBtn);
            this.Controls.Add(this.SumbitTextBox);
            this.Controls.Add(this.MainRTB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "ConsoleWin";
            this.Text = "Console";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConsoleWin_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox MainRTB;
        private System.Windows.Forms.TextBox SumbitTextBox;
        private System.Windows.Forms.Button SumbitBtn;
    }
}
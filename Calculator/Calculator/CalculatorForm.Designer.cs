namespace Calculator
{
    partial class CalculatorForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.One = new System.Windows.Forms.Button();
            this.Two = new System.Windows.Forms.Button();
            this.Three = new System.Windows.Forms.Button();
            this.Six = new System.Windows.Forms.Button();
            this.Five = new System.Windows.Forms.Button();
            this.Four = new System.Windows.Forms.Button();
            this.Nine = new System.Windows.Forms.Button();
            this.Eight = new System.Windows.Forms.Button();
            this.Seven = new System.Windows.Forms.Button();
            this.Zero = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(649, 20);
            this.textBox1.TabIndex = 0;
            // 
            // One
            // 
            this.One.Location = new System.Drawing.Point(13, 40);
            this.One.Name = "One";
            this.One.Size = new System.Drawing.Size(47, 41);
            this.One.TabIndex = 1;
            this.One.Tag = "1";
            this.One.Text = "1";
            this.One.UseVisualStyleBackColor = true;
            // 
            // Two
            // 
            this.Two.Location = new System.Drawing.Point(66, 40);
            this.Two.Name = "Two";
            this.Two.Size = new System.Drawing.Size(47, 41);
            this.Two.TabIndex = 2;
            this.Two.Tag = "2";
            this.Two.Text = "2";
            this.Two.UseVisualStyleBackColor = true;
            // 
            // Three
            // 
            this.Three.Location = new System.Drawing.Point(119, 40);
            this.Three.Name = "Three";
            this.Three.Size = new System.Drawing.Size(47, 41);
            this.Three.TabIndex = 3;
            this.Three.Tag = "3";
            this.Three.Text = "3";
            this.Three.UseVisualStyleBackColor = true;
            // 
            // Six
            // 
            this.Six.Location = new System.Drawing.Point(119, 87);
            this.Six.Name = "Six";
            this.Six.Size = new System.Drawing.Size(47, 41);
            this.Six.TabIndex = 6;
            this.Six.Tag = "6";
            this.Six.Text = "6";
            this.Six.UseVisualStyleBackColor = true;
            // 
            // Five
            // 
            this.Five.Location = new System.Drawing.Point(66, 87);
            this.Five.Name = "Five";
            this.Five.Size = new System.Drawing.Size(47, 41);
            this.Five.TabIndex = 5;
            this.Five.Tag = "5";
            this.Five.Text = "5";
            this.Five.UseVisualStyleBackColor = true;
            // 
            // Four
            // 
            this.Four.Location = new System.Drawing.Point(13, 87);
            this.Four.Name = "Four";
            this.Four.Size = new System.Drawing.Size(47, 41);
            this.Four.TabIndex = 4;
            this.Four.Tag = "4";
            this.Four.Text = "4";
            this.Four.UseVisualStyleBackColor = true;
            // 
            // Nine
            // 
            this.Nine.Location = new System.Drawing.Point(119, 134);
            this.Nine.Name = "Nine";
            this.Nine.Size = new System.Drawing.Size(47, 41);
            this.Nine.TabIndex = 9;
            this.Nine.Tag = "9";
            this.Nine.Text = "9";
            this.Nine.UseVisualStyleBackColor = true;
            // 
            // Eight
            // 
            this.Eight.Location = new System.Drawing.Point(66, 134);
            this.Eight.Name = "Eight";
            this.Eight.Size = new System.Drawing.Size(47, 41);
            this.Eight.TabIndex = 8;
            this.Eight.Tag = "8";
            this.Eight.Text = "8";
            this.Eight.UseVisualStyleBackColor = true;
            // 
            // Seven
            // 
            this.Seven.Location = new System.Drawing.Point(13, 134);
            this.Seven.Name = "Seven";
            this.Seven.Size = new System.Drawing.Size(47, 41);
            this.Seven.TabIndex = 7;
            this.Seven.Tag = "7";
            this.Seven.Text = "7";
            this.Seven.UseVisualStyleBackColor = true;
            // 
            // Zero
            // 
            this.Zero.Location = new System.Drawing.Point(66, 181);
            this.Zero.Name = "Zero";
            this.Zero.Size = new System.Drawing.Size(47, 41);
            this.Zero.TabIndex = 10;
            this.Zero.Tag = "0";
            this.Zero.Text = "0";
            this.Zero.UseVisualStyleBackColor = true;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 526);
            this.Controls.Add(this.Zero);
            this.Controls.Add(this.Nine);
            this.Controls.Add(this.Eight);
            this.Controls.Add(this.Seven);
            this.Controls.Add(this.Six);
            this.Controls.Add(this.Five);
            this.Controls.Add(this.Four);
            this.Controls.Add(this.Three);
            this.Controls.Add(this.Two);
            this.Controls.Add(this.One);
            this.Controls.Add(this.textBox1);
            this.Name = "CalculatorForm";
            this.Text = "CSC 8600 Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button One;
        private System.Windows.Forms.Button Two;
        private System.Windows.Forms.Button Three;
        private System.Windows.Forms.Button Six;
        private System.Windows.Forms.Button Five;
        private System.Windows.Forms.Button Four;
        private System.Windows.Forms.Button Nine;
        private System.Windows.Forms.Button Eight;
        private System.Windows.Forms.Button Seven;
        private System.Windows.Forms.Button Zero;
    }
}


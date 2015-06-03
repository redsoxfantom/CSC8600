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
            this.AnswerField = new System.Windows.Forms.TextBox();
            this.OneBtn = new System.Windows.Forms.Button();
            this.TwoBtn = new System.Windows.Forms.Button();
            this.ThreeBtn = new System.Windows.Forms.Button();
            this.SixBtn = new System.Windows.Forms.Button();
            this.FiveBtn = new System.Windows.Forms.Button();
            this.FourBtn = new System.Windows.Forms.Button();
            this.NineBtn = new System.Windows.Forms.Button();
            this.EightBtn = new System.Windows.Forms.Button();
            this.SevenBtn = new System.Windows.Forms.Button();
            this.ZeroBtn = new System.Windows.Forms.Button();
            this.PlusBtn = new System.Windows.Forms.Button();
            this.MinusBtn = new System.Windows.Forms.Button();
            this.MultiplyBtn = new System.Windows.Forms.Button();
            this.DivideBtn = new System.Windows.Forms.Button();
            this.EqualsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AnswerField
            // 
            this.AnswerField.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnswerField.Location = new System.Drawing.Point(13, 13);
            this.AnswerField.Name = "AnswerField";
            this.AnswerField.Size = new System.Drawing.Size(259, 30);
            this.AnswerField.TabIndex = 0;
            // 
            // OneBtn
            // 
            this.OneBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OneBtn.Location = new System.Drawing.Point(13, 49);
            this.OneBtn.Name = "OneBtn";
            this.OneBtn.Size = new System.Drawing.Size(47, 41);
            this.OneBtn.TabIndex = 1;
            this.OneBtn.Tag = "1";
            this.OneBtn.Text = "1";
            this.OneBtn.UseVisualStyleBackColor = true;
            this.OneBtn.Click += new System.EventHandler(this.numberBtnClick);
            // 
            // TwoBtn
            // 
            this.TwoBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TwoBtn.Location = new System.Drawing.Point(66, 49);
            this.TwoBtn.Name = "TwoBtn";
            this.TwoBtn.Size = new System.Drawing.Size(47, 41);
            this.TwoBtn.TabIndex = 2;
            this.TwoBtn.Tag = "2";
            this.TwoBtn.Text = "2";
            this.TwoBtn.UseVisualStyleBackColor = true;
            this.TwoBtn.Click += new System.EventHandler(this.numberBtnClick);
            // 
            // ThreeBtn
            // 
            this.ThreeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreeBtn.Location = new System.Drawing.Point(119, 49);
            this.ThreeBtn.Name = "ThreeBtn";
            this.ThreeBtn.Size = new System.Drawing.Size(47, 41);
            this.ThreeBtn.TabIndex = 3;
            this.ThreeBtn.Tag = "3";
            this.ThreeBtn.Text = "3";
            this.ThreeBtn.UseVisualStyleBackColor = true;
            this.ThreeBtn.Click += new System.EventHandler(this.numberBtnClick);
            // 
            // SixBtn
            // 
            this.SixBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SixBtn.Location = new System.Drawing.Point(119, 96);
            this.SixBtn.Name = "SixBtn";
            this.SixBtn.Size = new System.Drawing.Size(47, 41);
            this.SixBtn.TabIndex = 6;
            this.SixBtn.Tag = "6";
            this.SixBtn.Text = "6";
            this.SixBtn.UseVisualStyleBackColor = true;
            this.SixBtn.Click += new System.EventHandler(this.numberBtnClick);
            // 
            // FiveBtn
            // 
            this.FiveBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FiveBtn.Location = new System.Drawing.Point(66, 96);
            this.FiveBtn.Name = "FiveBtn";
            this.FiveBtn.Size = new System.Drawing.Size(47, 41);
            this.FiveBtn.TabIndex = 5;
            this.FiveBtn.Tag = "5";
            this.FiveBtn.Text = "5";
            this.FiveBtn.UseVisualStyleBackColor = true;
            this.FiveBtn.Click += new System.EventHandler(this.numberBtnClick);
            // 
            // FourBtn
            // 
            this.FourBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourBtn.Location = new System.Drawing.Point(13, 96);
            this.FourBtn.Name = "FourBtn";
            this.FourBtn.Size = new System.Drawing.Size(47, 41);
            this.FourBtn.TabIndex = 4;
            this.FourBtn.Tag = "4";
            this.FourBtn.Text = "4";
            this.FourBtn.UseVisualStyleBackColor = true;
            this.FourBtn.Click += new System.EventHandler(this.numberBtnClick);
            // 
            // NineBtn
            // 
            this.NineBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NineBtn.Location = new System.Drawing.Point(119, 143);
            this.NineBtn.Name = "NineBtn";
            this.NineBtn.Size = new System.Drawing.Size(47, 41);
            this.NineBtn.TabIndex = 9;
            this.NineBtn.Tag = "9";
            this.NineBtn.Text = "9";
            this.NineBtn.UseVisualStyleBackColor = true;
            this.NineBtn.Click += new System.EventHandler(this.numberBtnClick);
            // 
            // EightBtn
            // 
            this.EightBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EightBtn.Location = new System.Drawing.Point(66, 143);
            this.EightBtn.Name = "EightBtn";
            this.EightBtn.Size = new System.Drawing.Size(47, 41);
            this.EightBtn.TabIndex = 8;
            this.EightBtn.Tag = "8";
            this.EightBtn.Text = "8";
            this.EightBtn.UseVisualStyleBackColor = true;
            this.EightBtn.Click += new System.EventHandler(this.numberBtnClick);
            // 
            // SevenBtn
            // 
            this.SevenBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SevenBtn.Location = new System.Drawing.Point(13, 143);
            this.SevenBtn.Name = "SevenBtn";
            this.SevenBtn.Size = new System.Drawing.Size(47, 41);
            this.SevenBtn.TabIndex = 7;
            this.SevenBtn.Tag = "7";
            this.SevenBtn.Text = "7";
            this.SevenBtn.UseVisualStyleBackColor = true;
            this.SevenBtn.Click += new System.EventHandler(this.numberBtnClick);
            // 
            // ZeroBtn
            // 
            this.ZeroBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZeroBtn.Location = new System.Drawing.Point(66, 190);
            this.ZeroBtn.Name = "ZeroBtn";
            this.ZeroBtn.Size = new System.Drawing.Size(47, 41);
            this.ZeroBtn.TabIndex = 10;
            this.ZeroBtn.Tag = "0";
            this.ZeroBtn.Text = "0";
            this.ZeroBtn.UseVisualStyleBackColor = true;
            this.ZeroBtn.Click += new System.EventHandler(this.numberBtnClick);
            // 
            // PlusBtn
            // 
            this.PlusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlusBtn.Location = new System.Drawing.Point(172, 49);
            this.PlusBtn.Name = "PlusBtn";
            this.PlusBtn.Size = new System.Drawing.Size(47, 41);
            this.PlusBtn.TabIndex = 11;
            this.PlusBtn.Tag = "+";
            this.PlusBtn.Text = "+";
            this.PlusBtn.UseVisualStyleBackColor = true;
            // 
            // MinusBtn
            // 
            this.MinusBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinusBtn.Location = new System.Drawing.Point(172, 96);
            this.MinusBtn.Name = "MinusBtn";
            this.MinusBtn.Size = new System.Drawing.Size(47, 41);
            this.MinusBtn.TabIndex = 12;
            this.MinusBtn.Tag = "-";
            this.MinusBtn.Text = "-";
            this.MinusBtn.UseVisualStyleBackColor = true;
            // 
            // MultiplyBtn
            // 
            this.MultiplyBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MultiplyBtn.Location = new System.Drawing.Point(172, 143);
            this.MultiplyBtn.Name = "MultiplyBtn";
            this.MultiplyBtn.Size = new System.Drawing.Size(47, 41);
            this.MultiplyBtn.TabIndex = 13;
            this.MultiplyBtn.Tag = "*";
            this.MultiplyBtn.Text = "*";
            this.MultiplyBtn.UseVisualStyleBackColor = true;
            // 
            // DivideBtn
            // 
            this.DivideBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DivideBtn.Location = new System.Drawing.Point(172, 190);
            this.DivideBtn.Name = "DivideBtn";
            this.DivideBtn.Size = new System.Drawing.Size(47, 41);
            this.DivideBtn.TabIndex = 14;
            this.DivideBtn.Tag = "/";
            this.DivideBtn.Text = "/";
            this.DivideBtn.UseVisualStyleBackColor = true;
            // 
            // EqualsBtn
            // 
            this.EqualsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EqualsBtn.Location = new System.Drawing.Point(225, 49);
            this.EqualsBtn.Name = "EqualsBtn";
            this.EqualsBtn.Size = new System.Drawing.Size(47, 182);
            this.EqualsBtn.TabIndex = 15;
            this.EqualsBtn.Tag = "=";
            this.EqualsBtn.Text = "=";
            this.EqualsBtn.UseVisualStyleBackColor = true;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 238);
            this.Controls.Add(this.EqualsBtn);
            this.Controls.Add(this.DivideBtn);
            this.Controls.Add(this.MultiplyBtn);
            this.Controls.Add(this.MinusBtn);
            this.Controls.Add(this.PlusBtn);
            this.Controls.Add(this.ZeroBtn);
            this.Controls.Add(this.NineBtn);
            this.Controls.Add(this.EightBtn);
            this.Controls.Add(this.SevenBtn);
            this.Controls.Add(this.SixBtn);
            this.Controls.Add(this.FiveBtn);
            this.Controls.Add(this.FourBtn);
            this.Controls.Add(this.ThreeBtn);
            this.Controls.Add(this.TwoBtn);
            this.Controls.Add(this.OneBtn);
            this.Controls.Add(this.AnswerField);
            this.Name = "CalculatorForm";
            this.Text = "CSC 8600 Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AnswerField;
        private System.Windows.Forms.Button OneBtn;
        private System.Windows.Forms.Button TwoBtn;
        private System.Windows.Forms.Button ThreeBtn;
        private System.Windows.Forms.Button SixBtn;
        private System.Windows.Forms.Button FiveBtn;
        private System.Windows.Forms.Button FourBtn;
        private System.Windows.Forms.Button NineBtn;
        private System.Windows.Forms.Button EightBtn;
        private System.Windows.Forms.Button SevenBtn;
        private System.Windows.Forms.Button ZeroBtn;
        private System.Windows.Forms.Button PlusBtn;
        private System.Windows.Forms.Button MinusBtn;
        private System.Windows.Forms.Button MultiplyBtn;
        private System.Windows.Forms.Button DivideBtn;
        private System.Windows.Forms.Button EqualsBtn;
    }
}


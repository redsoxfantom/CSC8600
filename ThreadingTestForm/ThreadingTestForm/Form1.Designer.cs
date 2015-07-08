namespace ThreadingTestForm
{
    partial class Form1
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
            this.NonThreadedButton = new System.Windows.Forms.Button();
            this.ThreadedButton = new System.Windows.Forms.Button();
            this.NonThreadedOutput = new System.Windows.Forms.Label();
            this.ThreadedOutput = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NonThreadedButton
            // 
            this.NonThreadedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NonThreadedButton.Location = new System.Drawing.Point(93, 12);
            this.NonThreadedButton.Name = "NonThreadedButton";
            this.NonThreadedButton.Size = new System.Drawing.Size(180, 49);
            this.NonThreadedButton.TabIndex = 0;
            this.NonThreadedButton.Text = "Start NonThreaded Task";
            this.NonThreadedButton.UseVisualStyleBackColor = true;
            this.NonThreadedButton.Click += new System.EventHandler(this.NonThreadedButton_Click);
            // 
            // ThreadedButton
            // 
            this.ThreadedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreadedButton.Location = new System.Drawing.Point(93, 128);
            this.ThreadedButton.Name = "ThreadedButton";
            this.ThreadedButton.Size = new System.Drawing.Size(180, 49);
            this.ThreadedButton.TabIndex = 1;
            this.ThreadedButton.Text = "Start Threaded Task";
            this.ThreadedButton.UseVisualStyleBackColor = true;
            this.ThreadedButton.Click += new System.EventHandler(this.ThreadedButton_Click);
            // 
            // NonThreadedOutput
            // 
            this.NonThreadedOutput.AutoSize = true;
            this.NonThreadedOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NonThreadedOutput.Location = new System.Drawing.Point(80, 64);
            this.NonThreadedOutput.Name = "NonThreadedOutput";
            this.NonThreadedOutput.Size = new System.Drawing.Size(205, 17);
            this.NonThreadedOutput.TabIndex = 2;
            this.NonThreadedOutput.Text = "Output from NonThreaded task";
            // 
            // ThreadedOutput
            // 
            this.ThreadedOutput.AutoSize = true;
            this.ThreadedOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreadedOutput.Location = new System.Drawing.Point(80, 180);
            this.ThreadedOutput.Name = "ThreadedOutput";
            this.ThreadedOutput.Size = new System.Drawing.Size(205, 17);
            this.ThreadedOutput.TabIndex = 3;
            this.ThreadedOutput.Text = "Output from NonThreaded task";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(343, 139);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Example Input";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(112, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "RadioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 49);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(112, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "RadioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 76);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(112, 21);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "RadioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(330, 23);
            this.textBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 356);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ThreadedOutput);
            this.Controls.Add(this.NonThreadedOutput);
            this.Controls.Add(this.ThreadedButton);
            this.Controls.Add(this.NonThreadedButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NonThreadedButton;
        private System.Windows.Forms.Button ThreadedButton;
        private System.Windows.Forms.Label NonThreadedOutput;
        private System.Windows.Forms.Label ThreadedOutput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}


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
            this.SuspendLayout();
            // 
            // NonThreadedButton
            // 
            this.NonThreadedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NonThreadedButton.Location = new System.Drawing.Point(238, 12);
            this.NonThreadedButton.Name = "NonThreadedButton";
            this.NonThreadedButton.Size = new System.Drawing.Size(180, 49);
            this.NonThreadedButton.TabIndex = 0;
            this.NonThreadedButton.Text = "Start NonThreaded Task";
            this.NonThreadedButton.UseVisualStyleBackColor = true;
            // 
            // ThreadedButton
            // 
            this.ThreadedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreadedButton.Location = new System.Drawing.Point(238, 128);
            this.ThreadedButton.Name = "ThreadedButton";
            this.ThreadedButton.Size = new System.Drawing.Size(180, 49);
            this.ThreadedButton.TabIndex = 1;
            this.ThreadedButton.Text = "Start Threaded Task";
            this.ThreadedButton.UseVisualStyleBackColor = true;
            // 
            // NonThreadedOutput
            // 
            this.NonThreadedOutput.AutoSize = true;
            this.NonThreadedOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NonThreadedOutput.Location = new System.Drawing.Point(225, 64);
            this.NonThreadedOutput.Name = "NonThreadedOutput";
            this.NonThreadedOutput.Size = new System.Drawing.Size(205, 17);
            this.NonThreadedOutput.TabIndex = 2;
            this.NonThreadedOutput.Text = "Output from NonThreaded task";
            // 
            // ThreadedOutput
            // 
            this.ThreadedOutput.AutoSize = true;
            this.ThreadedOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThreadedOutput.Location = new System.Drawing.Point(225, 180);
            this.ThreadedOutput.Name = "ThreadedOutput";
            this.ThreadedOutput.Size = new System.Drawing.Size(205, 17);
            this.ThreadedOutput.TabIndex = 3;
            this.ThreadedOutput.Text = "Output from NonThreaded task";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 560);
            this.Controls.Add(this.ThreadedOutput);
            this.Controls.Add(this.NonThreadedOutput);
            this.Controls.Add(this.ThreadedButton);
            this.Controls.Add(this.NonThreadedButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NonThreadedButton;
        private System.Windows.Forms.Button ThreadedButton;
        private System.Windows.Forms.Label NonThreadedOutput;
        private System.Windows.Forms.Label ThreadedOutput;
    }
}


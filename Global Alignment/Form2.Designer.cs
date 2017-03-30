namespace Global_Alignment
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.seqLenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.refSeqTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.referenceSequenceRadioButton = new System.Windows.Forms.RadioButton();
            this.randomSequenceRadioButton = new System.Windows.Forms.RadioButton();
            this.form2_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.seqLenNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(157, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sequence Length";
            // 
            // seqLenNumericUpDown
            // 
            this.seqLenNumericUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.seqLenNumericUpDown.Location = new System.Drawing.Point(31, 72);
            this.seqLenNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.seqLenNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.seqLenNumericUpDown.Name = "seqLenNumericUpDown";
            this.seqLenNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.seqLenNumericUpDown.TabIndex = 1;
            this.seqLenNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // refSeqTextBox
            // 
            this.refSeqTextBox.Enabled = false;
            this.refSeqTextBox.Location = new System.Drawing.Point(31, 125);
            this.refSeqTextBox.Name = "refSeqTextBox";
            this.refSeqTextBox.Size = new System.Drawing.Size(120, 20);
            this.refSeqTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reference Sequence";
            // 
            // referenceSequenceRadioButton
            // 
            this.referenceSequenceRadioButton.AutoSize = true;
            this.referenceSequenceRadioButton.Location = new System.Drawing.Point(17, 30);
            this.referenceSequenceRadioButton.Name = "referenceSequenceRadioButton";
            this.referenceSequenceRadioButton.Size = new System.Drawing.Size(120, 17);
            this.referenceSequenceRadioButton.TabIndex = 4;
            this.referenceSequenceRadioButton.Text = "reference sequence";
            this.referenceSequenceRadioButton.UseVisualStyleBackColor = true;
            this.referenceSequenceRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // randomSequenceRadioButton
            // 
            this.randomSequenceRadioButton.AutoSize = true;
            this.randomSequenceRadioButton.Checked = true;
            this.randomSequenceRadioButton.Location = new System.Drawing.Point(143, 30);
            this.randomSequenceRadioButton.Name = "randomSequenceRadioButton";
            this.randomSequenceRadioButton.Size = new System.Drawing.Size(110, 17);
            this.randomSequenceRadioButton.TabIndex = 5;
            this.randomSequenceRadioButton.TabStop = true;
            this.randomSequenceRadioButton.Text = "random sequence";
            this.randomSequenceRadioButton.UseVisualStyleBackColor = true;
            this.randomSequenceRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // form2_ok
            // 
            this.form2_ok.Location = new System.Drawing.Point(100, 217);
            this.form2_ok.Name = "form2_ok";
            this.form2_ok.Size = new System.Drawing.Size(75, 23);
            this.form2_ok.TabIndex = 6;
            this.form2_ok.Text = "OK";
            this.form2_ok.UseVisualStyleBackColor = true;
            this.form2_ok.Click += new System.EventHandler(this.form2_ok_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.form2_ok);
            this.Controls.Add(this.randomSequenceRadioButton);
            this.Controls.Add(this.referenceSequenceRadioButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refSeqTextBox);
            this.Controls.Add(this.seqLenNumericUpDown);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seqLenNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown seqLenNumericUpDown;
        private System.Windows.Forms.TextBox refSeqTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton referenceSequenceRadioButton;
        private System.Windows.Forms.RadioButton randomSequenceRadioButton;
        private System.Windows.Forms.Button form2_ok;
    }
}
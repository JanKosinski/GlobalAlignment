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
            this.form2_ok = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numberOfSequencesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.errorsNumUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.rnaCheckBox = new System.Windows.Forms.CheckBox();
            this.dnaCheckBox = new System.Windows.Forms.CheckBox();
            this.randomSequenceRadioButton = new System.Windows.Forms.CheckBox();
            this.referenceSequenceRadioButton = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.seqLenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfSequencesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsNumUpDown)).BeginInit();
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
            this.seqLenNumericUpDown.Location = new System.Drawing.Point(31, 72);
            this.seqLenNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.seqLenNumericUpDown.Minimum = new decimal(new int[] {
            5,
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
            this.refSeqTextBox.Location = new System.Drawing.Point(31, 108);
            this.refSeqTextBox.Name = "refSeqTextBox";
            this.refSeqTextBox.Size = new System.Drawing.Size(120, 20);
            this.refSeqTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reference Sequence";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number of Sequences To Genaerate";
            // 
            // numberOfSequencesNumericUpDown
            // 
            this.numberOfSequencesNumericUpDown.Location = new System.Drawing.Point(31, 174);
            this.numberOfSequencesNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberOfSequencesNumericUpDown.Name = "numberOfSequencesNumericUpDown";
            this.numberOfSequencesNumericUpDown.Size = new System.Drawing.Size(60, 20);
            this.numberOfSequencesNumericUpDown.TabIndex = 8;
            this.numberOfSequencesNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Number of errors";
            // 
            // errorsNumUpDown
            // 
            this.errorsNumUpDown.Location = new System.Drawing.Point(31, 144);
            this.errorsNumUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.errorsNumUpDown.Name = "errorsNumUpDown";
            this.errorsNumUpDown.Size = new System.Drawing.Size(120, 20);
            this.errorsNumUpDown.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sequence type";
            // 
            // rnaCheckBox
            // 
            this.rnaCheckBox.AutoSize = true;
            this.rnaCheckBox.Location = new System.Drawing.Point(31, 48);
            this.rnaCheckBox.Name = "rnaCheckBox";
            this.rnaCheckBox.Size = new System.Drawing.Size(41, 17);
            this.rnaCheckBox.TabIndex = 12;
            this.rnaCheckBox.Text = "rna";
            this.rnaCheckBox.UseVisualStyleBackColor = true;
            this.rnaCheckBox.CheckedChanged += new System.EventHandler(this.rnaCheckBox_CheckedChanged);
            // 
            // dnaCheckBox
            // 
            this.dnaCheckBox.AutoSize = true;
            this.dnaCheckBox.Checked = true;
            this.dnaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dnaCheckBox.Location = new System.Drawing.Point(160, 48);
            this.dnaCheckBox.Name = "dnaCheckBox";
            this.dnaCheckBox.Size = new System.Drawing.Size(44, 17);
            this.dnaCheckBox.TabIndex = 13;
            this.dnaCheckBox.Text = "dna";
            this.dnaCheckBox.UseVisualStyleBackColor = true;
            this.dnaCheckBox.CheckedChanged += new System.EventHandler(this.dnaCheckBox_CheckedChanged);
            // 
            // randomSequenceRadioButton
            // 
            this.randomSequenceRadioButton.AutoSize = true;
            this.randomSequenceRadioButton.Checked = true;
            this.randomSequenceRadioButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.randomSequenceRadioButton.Location = new System.Drawing.Point(31, 12);
            this.randomSequenceRadioButton.Name = "randomSequenceRadioButton";
            this.randomSequenceRadioButton.Size = new System.Drawing.Size(110, 17);
            this.randomSequenceRadioButton.TabIndex = 14;
            this.randomSequenceRadioButton.Text = "randomSequence";
            this.randomSequenceRadioButton.UseVisualStyleBackColor = true;
            this.randomSequenceRadioButton.CheckedChanged += new System.EventHandler(this.randomSequenceRadioButton_CheckedChanged);
            // 
            // referenceSequenceRadioButton
            // 
            this.referenceSequenceRadioButton.AutoSize = true;
            this.referenceSequenceRadioButton.Location = new System.Drawing.Point(160, 12);
            this.referenceSequenceRadioButton.Name = "referenceSequenceRadioButton";
            this.referenceSequenceRadioButton.Size = new System.Drawing.Size(123, 17);
            this.referenceSequenceRadioButton.TabIndex = 15;
            this.referenceSequenceRadioButton.Text = "reference Sequence";
            this.referenceSequenceRadioButton.UseVisualStyleBackColor = true;
            this.referenceSequenceRadioButton.CheckedChanged += new System.EventHandler(this.referenceSequenceRadioButton_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 276);
            this.Controls.Add(this.referenceSequenceRadioButton);
            this.Controls.Add(this.randomSequenceRadioButton);
            this.Controls.Add(this.dnaCheckBox);
            this.Controls.Add(this.rnaCheckBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.errorsNumUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numberOfSequencesNumericUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.form2_ok);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.refSeqTextBox);
            this.Controls.Add(this.seqLenNumericUpDown);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Random Input";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.seqLenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfSequencesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorsNumUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown seqLenNumericUpDown;
        private System.Windows.Forms.TextBox refSeqTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button form2_ok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numberOfSequencesNumericUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown errorsNumUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox rnaCheckBox;
        private System.Windows.Forms.CheckBox dnaCheckBox;
        private System.Windows.Forms.CheckBox randomSequenceRadioButton;
        private System.Windows.Forms.CheckBox referenceSequenceRadioButton;
    }
}
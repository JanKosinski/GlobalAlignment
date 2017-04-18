namespace Global_Alignment
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.randomButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.saveToFASTAButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(15, 307);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(164, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Upload FASTA";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // randomButton
            // 
            this.randomButton.Location = new System.Drawing.Point(473, 307);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(195, 23);
            this.randomButton.TabIndex = 3;
            this.randomButton.Text = "Random Input";
            this.randomButton.UseVisualStyleBackColor = true;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView.Size = new System.Drawing.Size(672, 247);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_RowValidating);
            // 
            // saveToFASTAButton
            // 
            this.saveToFASTAButton.Location = new System.Drawing.Point(198, 306);
            this.saveToFASTAButton.Name = "saveToFASTAButton";
            this.saveToFASTAButton.Size = new System.Drawing.Size(251, 23);
            this.saveToFASTAButton.TabIndex = 5;
            this.saveToFASTAButton.Text = "Save To FASTA";
            this.saveToFASTAButton.UseVisualStyleBackColor = true;
            this.saveToFASTAButton.Click += new System.EventHandler(this.saveToFASTAButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(198, 360);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(251, 23);
            this.runButton.TabIndex = 6;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 425);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.saveToFASTAButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.randomButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button randomButton;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button saveToFASTAButton;
        private System.Windows.Forms.Button runButton;
    }
}


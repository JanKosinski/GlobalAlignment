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
            this.outputBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.probabilityOfMutationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.populationSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.iterationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.stopAfterUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.pauseResumeButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityOfMutationsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopAfterUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(12, 267);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(102, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Upload FASTA";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // randomButton
            // 
            this.randomButton.Location = new System.Drawing.Point(234, 267);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(99, 23);
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
            this.dataGridView.Size = new System.Drawing.Size(1182, 220);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_RowValidating);
            // 
            // saveToFASTAButton
            // 
            this.saveToFASTAButton.Location = new System.Drawing.Point(120, 267);
            this.saveToFASTAButton.Name = "saveToFASTAButton";
            this.saveToFASTAButton.Size = new System.Drawing.Size(108, 23);
            this.saveToFASTAButton.TabIndex = 5;
            this.saveToFASTAButton.Text = "Save To FASTA";
            this.saveToFASTAButton.UseVisualStyleBackColor = true;
            this.saveToFASTAButton.Click += new System.EventHandler(this.saveToFASTAButton_Click);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(353, 356);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(107, 23);
            this.runButton.TabIndex = 6;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // outputBox
            // 
            this.outputBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputBox.Location = new System.Drawing.Point(15, 463);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputBox.Size = new System.Drawing.Size(1179, 101);
            this.outputBox.TabIndex = 7;
            this.outputBox.WordWrap = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 447);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Algorithm Parameters";
            // 
            // probabilityOfMutationsUpDown
            // 
            this.probabilityOfMutationsUpDown.Location = new System.Drawing.Point(12, 325);
            this.probabilityOfMutationsUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.probabilityOfMutationsUpDown.Name = "probabilityOfMutationsUpDown";
            this.probabilityOfMutationsUpDown.Size = new System.Drawing.Size(120, 20);
            this.probabilityOfMutationsUpDown.TabIndex = 10;
            this.probabilityOfMutationsUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 329);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Probability of Mutations";
            // 
            // populationSizeUpDown
            // 
            this.populationSizeUpDown.Location = new System.Drawing.Point(12, 351);
            this.populationSizeUpDown.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.populationSizeUpDown.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.populationSizeUpDown.Name = "populationSizeUpDown";
            this.populationSizeUpDown.Size = new System.Drawing.Size(120, 20);
            this.populationSizeUpDown.TabIndex = 12;
            this.populationSizeUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(141, 356);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Population Size";
            // 
            // iterationsUpDown
            // 
            this.iterationsUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.iterationsUpDown.Location = new System.Drawing.Point(12, 378);
            this.iterationsUpDown.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.iterationsUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.iterationsUpDown.Name = "iterationsUpDown";
            this.iterationsUpDown.Size = new System.Drawing.Size(120, 20);
            this.iterationsUpDown.TabIndex = 16;
            this.iterationsUpDown.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Max Number of Iterations to Execute";
            // 
            // stopAfterUpDown
            // 
            this.stopAfterUpDown.Location = new System.Drawing.Point(12, 405);
            this.stopAfterUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.stopAfterUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.stopAfterUpDown.Name = "stopAfterUpDown";
            this.stopAfterUpDown.Size = new System.Drawing.Size(120, 20);
            this.stopAfterUpDown.TabIndex = 18;
            this.stopAfterUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(141, 409);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Stop after N Iterations without Benefits";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(486, 356);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(280, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Visible = false;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(772, 361);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(48, 13);
            this.progressLabel.TabIndex = 22;
            this.progressLabel.Text = "Progress";
            this.progressLabel.Visible = false;
            // 
            // pauseResumeButton
            // 
            this.pauseResumeButton.Location = new System.Drawing.Point(353, 386);
            this.pauseResumeButton.Name = "pauseResumeButton";
            this.pauseResumeButton.Size = new System.Drawing.Size(107, 23);
            this.pauseResumeButton.TabIndex = 23;
            this.pauseResumeButton.Text = "Pause";
            this.pauseResumeButton.UseVisualStyleBackColor = true;
            this.pauseResumeButton.Visible = false;
            this.pauseResumeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // abortButton
            // 
            this.abortButton.Location = new System.Drawing.Point(353, 415);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(107, 23);
            this.abortButton.TabIndex = 24;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Visible = false;
            this.abortButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 576);
            this.Controls.Add(this.abortButton);
            this.Controls.Add(this.pauseResumeButton);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.stopAfterUpDown);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.iterationsUpDown);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.populationSizeUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.probabilityOfMutationsUpDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.saveToFASTAButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.randomButton);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Multiple Sequence Alignment";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityOfMutationsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopAfterUpDown)).EndInit();
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
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown probabilityOfMutationsUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown populationSizeUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown iterationsUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown stopAfterUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button pauseResumeButton;
        private System.Windows.Forms.Button abortButton;
    }
}


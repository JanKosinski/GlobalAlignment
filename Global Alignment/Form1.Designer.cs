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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveToFASTAButton = new System.Windows.Forms.Button();
            this.randomButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.runGroupBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.iterationsWithoutBenefits = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.benefitProgressBar = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.runButton = new System.Windows.Forms.Button();
            this.pauseResumeButton = new System.Windows.Forms.Button();
            this.abortButton = new System.Windows.Forms.Button();
            this.algParameters = new System.Windows.Forms.GroupBox();
            this.probabilityOfMutationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.populationSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.iterationsUpDown = new System.Windows.Forms.NumericUpDown();
            this.stopAfterUpDown = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.inputGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.runGroupBox.SuspendLayout();
            this.algParameters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityOfMutationsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopAfterUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inputGroupBox.Controls.Add(this.loadButton);
            this.inputGroupBox.Controls.Add(this.saveToFASTAButton);
            this.inputGroupBox.Controls.Add(this.randomButton);
            this.inputGroupBox.Controls.Add(this.dataGridView);
            this.inputGroupBox.Location = new System.Drawing.Point(25, 12);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(1134, 267);
            this.inputGroupBox.TabIndex = 30;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Input";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(233, 224);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(102, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Upload FASTA";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveToFASTAButton
            // 
            this.saveToFASTAButton.Location = new System.Drawing.Point(119, 224);
            this.saveToFASTAButton.Name = "saveToFASTAButton";
            this.saveToFASTAButton.Size = new System.Drawing.Size(108, 23);
            this.saveToFASTAButton.TabIndex = 5;
            this.saveToFASTAButton.Text = "Save To FASTA";
            this.saveToFASTAButton.UseVisualStyleBackColor = true;
            this.saveToFASTAButton.Click += new System.EventHandler(this.saveToFASTAButton_Click);
            // 
            // randomButton
            // 
            this.randomButton.Location = new System.Drawing.Point(12, 224);
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
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 19);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView.Size = new System.Drawing.Size(1110, 199);
            this.dataGridView.TabIndex = 4;
            this.dataGridView.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView_RowValidating);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.outputBox);
            this.groupBox1.Location = new System.Drawing.Point(25, 443);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 297);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // outputBox
            // 
            this.outputBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.outputBox.Location = new System.Drawing.Point(6, 19);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputBox.Size = new System.Drawing.Size(698, 259);
            this.outputBox.TabIndex = 7;
            this.outputBox.WordWrap = false;
            // 
            // runGroupBox
            // 
            this.runGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.runGroupBox.Controls.Add(this.button1);
            this.runGroupBox.Controls.Add(this.iterationsWithoutBenefits);
            this.runGroupBox.Controls.Add(this.progressLabel);
            this.runGroupBox.Controls.Add(this.benefitProgressBar);
            this.runGroupBox.Controls.Add(this.progressBar1);
            this.runGroupBox.Controls.Add(this.runButton);
            this.runGroupBox.Controls.Add(this.pauseResumeButton);
            this.runGroupBox.Controls.Add(this.abortButton);
            this.runGroupBox.Location = new System.Drawing.Point(399, 301);
            this.runGroupBox.Name = "runGroupBox";
            this.runGroupBox.Size = new System.Drawing.Size(760, 136);
            this.runGroupBox.TabIndex = 31;
            this.runGroupBox.TabStop = false;
            this.runGroupBox.Text = "Run Section";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 34;
            this.button1.Text = "Run Tests";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // iterationsWithoutBenefits
            // 
            this.iterationsWithoutBenefits.AutoSize = true;
            this.iterationsWithoutBenefits.Location = new System.Drawing.Point(424, 53);
            this.iterationsWithoutBenefits.Name = "iterationsWithoutBenefits";
            this.iterationsWithoutBenefits.Size = new System.Drawing.Size(131, 13);
            this.iterationsWithoutBenefits.TabIndex = 26;
            this.iterationsWithoutBenefits.Text = "Iterations Without Benefits";
            this.iterationsWithoutBenefits.Visible = false;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(424, 24);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(48, 13);
            this.progressLabel.TabIndex = 22;
            this.progressLabel.Text = "Progress";
            this.progressLabel.Visible = false;
            // 
            // benefitProgressBar
            // 
            this.benefitProgressBar.Location = new System.Drawing.Point(138, 48);
            this.benefitProgressBar.Name = "benefitProgressBar";
            this.benefitProgressBar.Size = new System.Drawing.Size(280, 23);
            this.benefitProgressBar.TabIndex = 25;
            this.benefitProgressBar.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(138, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(280, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Visible = false;
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(6, 19);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(107, 23);
            this.runButton.TabIndex = 6;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // pauseResumeButton
            // 
            this.pauseResumeButton.Location = new System.Drawing.Point(6, 48);
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
            this.abortButton.Location = new System.Drawing.Point(6, 77);
            this.abortButton.Name = "abortButton";
            this.abortButton.Size = new System.Drawing.Size(107, 23);
            this.abortButton.TabIndex = 24;
            this.abortButton.Text = "Abort";
            this.abortButton.UseVisualStyleBackColor = true;
            this.abortButton.Visible = false;
            this.abortButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // algParameters
            // 
            this.algParameters.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.algParameters.Controls.Add(this.probabilityOfMutationsUpDown);
            this.algParameters.Controls.Add(this.populationSizeUpDown);
            this.algParameters.Controls.Add(this.iterationsUpDown);
            this.algParameters.Controls.Add(this.stopAfterUpDown);
            this.algParameters.Controls.Add(this.label4);
            this.algParameters.Controls.Add(this.label6);
            this.algParameters.Controls.Add(this.label5);
            this.algParameters.Controls.Add(this.label7);
            this.algParameters.Location = new System.Drawing.Point(25, 301);
            this.algParameters.Name = "algParameters";
            this.algParameters.Size = new System.Drawing.Size(356, 125);
            this.algParameters.TabIndex = 28;
            this.algParameters.TabStop = false;
            this.algParameters.Text = "Algorithm Parameters";
            // 
            // probabilityOfMutationsUpDown
            // 
            this.probabilityOfMutationsUpDown.Location = new System.Drawing.Point(8, 21);
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
            // populationSizeUpDown
            // 
            this.populationSizeUpDown.Location = new System.Drawing.Point(8, 46);
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
            // iterationsUpDown
            // 
            this.iterationsUpDown.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.iterationsUpDown.Location = new System.Drawing.Point(8, 72);
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
            // stopAfterUpDown
            // 
            this.stopAfterUpDown.Location = new System.Drawing.Point(8, 98);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Probability of Mutations";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(134, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Population Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Max Number of Iterations to Execute";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(134, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Stop after N Iterations without Benefits";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(767, 443);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(374, 300);
            this.chart1.TabIndex = 33;
            this.chart1.Text = "chart1";
            this.chart1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1186, 763);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.runGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.algParameters);
            this.Controls.Add(this.inputGroupBox);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Name = "Form1";
            this.Text = "Multiple Sequence Alignment";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.inputGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.runGroupBox.ResumeLayout(false);
            this.runGroupBox.PerformLayout();
            this.algParameters.ResumeLayout(false);
            this.algParameters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityOfMutationsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.populationSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stopAfterUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveToFASTAButton;
        private System.Windows.Forms.Button randomButton;
        public System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.GroupBox runGroupBox;
        private System.Windows.Forms.Label iterationsWithoutBenefits;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.ProgressBar benefitProgressBar;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Button pauseResumeButton;
        private System.Windows.Forms.Button abortButton;
        private System.Windows.Forms.GroupBox algParameters;
        private System.Windows.Forms.NumericUpDown probabilityOfMutationsUpDown;
        private System.Windows.Forms.NumericUpDown populationSizeUpDown;
        private System.Windows.Forms.NumericUpDown iterationsUpDown;
        private System.Windows.Forms.NumericUpDown stopAfterUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
    }
}


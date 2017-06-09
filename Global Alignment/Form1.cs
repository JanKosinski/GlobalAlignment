using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Global_Alignment
{
    public partial class Form1 : Form
    {
        public DataTable dt;
        public Form1()
        {   
            //TODO add sequence length to data grid view. Non editable
            InitializeComponent();
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Sequence ID", typeof(string)));
            dt.Columns.Add(new DataColumn("Sequence", typeof(string)));   
            dataGridView.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        volatile bool Active = true;
        volatile bool Abort = false;

        volatile string BestAlignmentUpToDate = "";
        volatile int BestMisMatchesUpToDate;
        volatile int BestFitnessUpToDate = 0;

        private void randomButton_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
            this.Enabled = false;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {   
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK) {
                dt.Clear();
                string path = ofd.FileName;
                string text = File.Exists(path) ? System.IO.File.ReadAllText(path) : "File doesn't exist error";    // reading from file; if file does not exist insert to text error message
                if (text == "File doesn't exist error") { Console.WriteLine("File doesn't exist");  return;  }  // if file does not exist
                Regex fastaRegex = new Regex(@"(>\S+\s+([atgcuryswkmbdhvnATGCURYSWKMBDHVN\s])+){2,}");  // fasta file validation. Fasta file must have at least 2 sequences
                Match fastaMatch = fastaRegex.Match(text);
                if (fastaMatch.Value.Trim() != text.Trim()) {
                    MessageBox.Show("Wrong file format! Please note that fasta header should not contain whitespaces!");
                    return;
                }
                // end of fasta validation
                Regex regex = new Regex(@">\S+\s+");
                Match match = regex.Match(text);    // taking sequence names from fasta
                string[] sequences = Regex.Split(text, @">\S+\s+"); //taking sequences from fasta
                sequences = sequences.Where(x => !string.IsNullOrEmpty(x)).ToArray();   //linq. Removing empty elements from array
                List<string> names = new List<string>();
                while (true)
                {
                    if (match.Success)
                    {
                        names.Add((match.Value).Trim());    // looking for sequence names as long as regex can find next one
                        match = match.NextMatch();
                    }
                    else
                    {
                        break;
                    }
                }
                if (names.Count != sequences.Length) {  // additional safety procedure. ?
                    MessageBox.Show("Wrong file format!"); //?
                    return; //?
                }
                for (int j = 0; j< names.Count; j++){
                    this.dt.Rows.Add(new object[] { Regex.Replace(names[j], @"\s+", ""), Regex.Replace(sequences[j], @"\s+", "") });    // adding rows to data table
                }
            }     
        }



        private bool validateDataTable(bool checkNonEmptyRows = false) {  // sprawdza czy arkusz nie zawiera błedów. Jeżeli zawiera to zakreśl wiersz na czerwono
            int seqLen;
            try
            {
                seqLen = this.dataGridView.Rows[0].Cells[1].Value.ToString().Length;
            }
            catch (NullReferenceException e) {
                Console.WriteLine(e);
                return false;
            }
            Regex sequenceRegex;
            Match sequenceMatch;
            bool temp = false;
            foreach (DataGridViewRow row in this.dataGridView.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;   // przed walidacja ustawia wszystkie na biało. Żeby już poprawone wiersze nie były nadal czerwone
            } 
            foreach (DataGridViewRow row in this.dataGridView.Rows)
            {
                if (!row.IsNewRow) {    // jeżeli to nie jest nowy wiersz (osttani)
                    if (row.Cells[1].Value.ToString().Length != seqLen) {   // jezeli wszytskie sekwencje nie sa rownej dlugosci
                        temp = true;
                    }
                    sequenceRegex = new Regex(@"^[atgcuryswkmbdhvnATGCURYSWKMBDHVN\s]+$");  // sprawdzamy poprawnosc sekwencji
                    sequenceMatch = sequenceRegex.Match(row.Cells[1].Value.ToString());
                    if (sequenceMatch.Value.Trim() != row.Cells[1].Value.ToString().Trim() || row.Cells[0].Value.ToString().Length == 0 || row.Cells[1].Value.ToString().Length == 0)
                    {   // jezeli cos jest nie tak to zmien kolor na czerwony
                        row.DefaultCellStyle.BackColor = Color.Red;
                        temp = true;
                    }
                }            
            }
            //sprawdzanie ilosci niepustych wierszy
            if (checkNonEmptyRows)
            {
                string sequences = "";
                int nonEmptyRowsNum = 0;
                foreach (DataGridViewRow row in this.dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        sequences += row.Cells[1].Value.ToString();
                        nonEmptyRowsNum++;
                    }
                }
                if (sequences.ToUpper().Contains("U") && sequences.ToUpper().Contains("T")) {
                    MessageBox.Show("Your sequences contains U and T");
                    return false;
                }
                if (nonEmptyRowsNum < 2) { MessageBox.Show("You should have at least 2 non empty rows"); return false; }
            }
            if (temp) {
                return false;
            }
            return true;
        }

        private void saveToFASTAButton_Click(object sender, EventArgs e)    // zapis do pliku fasta
        {
            if (validateDataTable(true))    // jezeli datgridview nie zawiera bledow
            {
                OpenFileDialog ofd = new OpenFileDialog();  // wybieramy lokalizacje pliku
                ofd.CheckFileExists = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string lines = "";
                    string path = ofd.FileName;
                    string replacedString = "";
                    System.IO.StreamWriter file = new System.IO.StreamWriter(path);
                    foreach (DataRow row in this.dt.Rows)
                    {
                        replacedString = Regex.Replace(row["Sequence ID"].ToString(), @"^>", "");   // usuwamy znaczek >, by uniknac jego dublowania
                        lines += ">" + replacedString + Environment.NewLine;
                        lines += row["Sequence"].ToString() + Environment.NewLine;
                    }
                    MessageBox.Show("Successfully saved");
                    file.WriteLine(lines);  // zapisujemy do pliku
                    file.Close();
                }
            }
            else {
                MessageBox.Show("Table contains errors. Please note that each sequence must be of equal length.");
            }
        }

        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)   // walidacja wiersza
        {
            validateDataTable();
        }

        public class ReportProgress {
            public GeneticAlgorithm GenAlg { get; set; }
            public int NumberOfIterationsWithoutBenefits { get; set; }

            public ReportProgress(GeneticAlgorithm _genAlg, int _num) {
                this.GenAlg = _genAlg;
                this.NumberOfIterationsWithoutBenefits = _num;
            }
        }


        private void runButton_Click(object sender, EventArgs e)
        {
            BestFitnessUpToDate = 0;
            BestAlignmentUpToDate = "";
            //BestMisMatchesUpToDate = 99999;
            if (!validateDataTable(true)) { MessageBox.Show("There are some errors in DataGridView"); return;  }
            Abort = false;

            //validation
            if (iterationsUpDown.Value < stopAfterUpDown.Value) {
                stopAfterUpDown.Value = iterationsUpDown.Value;
            }
            //validation

            chart1.Series.Clear();
            var s = new Series("Funkcja celu");
            s.ChartType = SeriesChartType.Point;
            chart1.Series.Add(s);
            // buttons visibility
            abortButton.Visible = true;
            runButton.Enabled = false;
            progressBar1.Visible = true;
            progressLabel.Visible = true;
            pauseResumeButton.Visible = true;
            benefitProgressBar.Visible = true;
            iterationsWithoutBenefits.Visible = true;
            chart1.Visible = true;
            abortButton.Enabled = true;
            progressBar1.Enabled = true;
            progressLabel.Enabled = true;
            pauseResumeButton.Enabled = true;
            benefitProgressBar.Enabled = true;
            iterationsWithoutBenefits.Enabled = true;
            //chart1.Enabled = true;
            //

            this.outputBox.Clear();
            if (this.dt.Rows.Count >= 2)
            {   
                // progress bars ranges
                this.progressBar1.Maximum = Convert.ToInt32(this.iterationsUpDown.Value);
                this.progressBar1.Minimum = 0;

                this.benefitProgressBar.Minimum = 0;
                this.benefitProgressBar.Maximum = Convert.ToInt32(stopAfterUpDown.Value);
                //

                List<string> sequencesToAlign = new List<string>();
                foreach (DataRow row in this.dt.Rows)
                {
                    sequencesToAlign.Add(row["Sequence"].ToString());
                }
                
                GeneticAlgorithm genAlg = new GeneticAlgorithm(Convert.ToInt32(populationSizeUpDown.Value), sequencesToAlign, Convert.ToInt32(probabilityOfMutationsUpDown.Value));

                BackgroundWorker bw = new BackgroundWorker();
                // this allows our worker to report progress during work
                bw.WorkerReportsProgress = true;
                // what to do in the background thread
                bw.DoWork += new DoWorkEventHandler(
                delegate (object o, DoWorkEventArgs args)
                {
                    int prvBestAligment = 0;
                    BackgroundWorker b = o as BackgroundWorker;
                    Random rnd = new Random();
                    int mut;
                    int iterations = Convert.ToInt32(iterationsUpDown.Value);
                    genAlg.createRandomPopulation();
                    int numberOfIterationsWithoutBenefits = 0;
                    for (int it = 0; it < iterations; it++)
                    {


                        if (Abort) {
                            break;
                        }
                        if (Active)
                        {
                            //genetic algorithm
                            genAlg.convertBoolToAlignment();

                            if (it > 0)
                            {
                                prvBestAligment = genAlg.BestAlignment.Fitness;
                            }

                            genAlg.fitnessFunction();

                            if (it >= 1 && prvBestAligment == genAlg.BestAlignment.Fitness)
                            {
                                numberOfIterationsWithoutBenefits++;
                                if (numberOfIterationsWithoutBenefits == stopAfterUpDown.Value)
                                {
                                    Abort = true;
                                }
                            }
                            else
                            {
                                numberOfIterationsWithoutBenefits = 0;
                            }

                            genAlg.selection();
                            genAlg.crossover();
                            mut = rnd.Next(0, 101);
                            if (mut <= genAlg.ProbabilityOfMutations)
                            {
                                mut = rnd.Next(0, genAlg.PopulationSize);
                                genAlg.population[mut] = genAlg.mutation(genAlg.population[mut]);
                            }

                            b.ReportProgress(it, new ReportProgress(genAlg, numberOfIterationsWithoutBenefits));
                        }
                        else
                        {
                            while (!Active)
                            {
                                Thread.Sleep(100);
                            }
                        }
                    }
                    
                });
                // what to do when progress changed (update the progress bar for example)
                bw.ProgressChanged += new ProgressChangedEventHandler(
                delegate (object o, ProgressChangedEventArgs args)
                {
                    ReportProgress rep = (ReportProgress)args.UserState;
                    this.progressBar1.Value = args.ProgressPercentage;
                    this.benefitProgressBar.Value = rep.NumberOfIterationsWithoutBenefits;
                    if(rep.NumberOfIterationsWithoutBenefits == stopAfterUpDown.Value) {
                        this.outputBox.Text += "You've reached max number of iterations without benefits" + Environment.NewLine;
                    }
                    if (rep.GenAlg.BestAlignment.Fitness > BestFitnessUpToDate) {
                        BestFitnessUpToDate = rep.GenAlg.BestAlignment.Fitness;
                        this.outputBox.Text += "Best Fitness Up To Date: " + BestFitnessUpToDate.ToString() + Environment.NewLine + " MisMatches: " + rep.GenAlg.BestAlignment.MisMatches + Environment.NewLine;
                        BestAlignmentUpToDate = "";
                        for (int i = 0; i < rep.GenAlg.BestAlignment.alignment.Count; i++)
                        {
                            BestAlignmentUpToDate += string.Join(" ", rep.GenAlg.BestAlignment.alignment[i].ToArray());
                            BestAlignmentUpToDate += Environment.NewLine;
                            BestMisMatchesUpToDate = rep.GenAlg.BestAlignment.MisMatches;
                        }
                    }

                    s.Points.AddXY(args.ProgressPercentage + 1, BestFitnessUpToDate);
                    

                });

                // what to do when worker completes its task (notify the user)
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(
                delegate (object o, RunWorkerCompletedEventArgs args)
                {   
                    this.outputBox.Text += "DONE!"+Environment.NewLine+BestAlignmentUpToDate+Environment.NewLine;
                    this.outputBox.Text += "MisMatches: " +BestMisMatchesUpToDate.ToString();
                    this.progressBar1.Enabled = false;
                    this.progressLabel.Enabled = false;
                    this.pauseResumeButton.Enabled = false;
                    this.abortButton.Enabled = false;
                    this.benefitProgressBar.Enabled = false;
                    this.iterationsWithoutBenefits.Enabled = false;
                    this.runButton.Enabled = true;
                    //this.chart1.Visible = false;

                });

                bw.RunWorkerAsync();

            }
            else {
                MessageBox.Show("Incorrect Data");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pauseResumeButton.Text == "Pause")
            {
                Active = false;
                abortButton.Enabled = false;
                pauseResumeButton.Text = "Resume";
                this.outputBox.Text = "Best Alignment Up to Date:" + Environment.NewLine + BestAlignmentUpToDate + Environment.NewLine;
                this.outputBox.Text += "MisMatches: " + BestMisMatchesUpToDate.ToString() + Environment.NewLine;
            }
            else {
                Active = true;
                abortButton.Enabled = true;
                pauseResumeButton.Text = "Pause";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Abort = true;
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Test test = new Test();
            test.run();
        }
    }
}

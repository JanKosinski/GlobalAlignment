using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                string path = ofd.FileName;
                string text = File.Exists(path) ? System.IO.File.ReadAllText(path) : "File doesn't exist error";    // reading from file; if file does not exist insert to text error message
                if (text == "File doesn't exist error") { Console.WriteLine("File doesn't exist");  return;  }  // if file does not exist
                Regex fastaRegex = new Regex(@"(>\S+\s+([atgcuryswkmbdhvnATGCURYSWKMBDHVN\s])+){2,}");  // fasta file validation. Fasta file must have at least 2 sequences
                Match fastaMatch = fastaRegex.Match(text);
                if (fastaMatch.Value.Trim() != text.Trim()) {
                    Console.WriteLine("This is not valid fasta format!");
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
                    Console.WriteLine("Wrong file format!"); //?
                    return; //?
                }
                for (int j = 0; j< names.Count; j++){
                    this.dt.Rows.Add(new object[] { Regex.Replace(names[j], @"\s+", ""), Regex.Replace(sequences[j], @"\s+", "") });    // adding rows to data table
                }


            }
            
        }



        private bool validateDataTable() {  // sprawdza czy arkusz nie zawiera błedów. Jeżeli zawiera to zakreśl wiersz na czerwono
            int seqLen = this.dataGridView.Rows[0].Cells[1].Value.ToString().Length;
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
            if (temp) {
                return false;
            }
            return true;
        }

        private void saveToFASTAButton_Click(object sender, EventArgs e)    // zapis do pliku fasta
        {
            if (validateDataTable())    // jezeli datgridview nie zawiera bledow
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

        private void runButton_Click(object sender, EventArgs e)
        {   
            // TODO when datagridview is empty -> validation
            
            List<string>sequencesToAlign = new List<string>();
            foreach (DataRow row in this.dt.Rows)
            {
                sequencesToAlign.Add(row["Sequence"].ToString());
            }
            GeneticAlgorithm genAlg = new GeneticAlgorithm(100, sequencesToAlign);
            genAlg.runAlgorithm();

        }
    }
}

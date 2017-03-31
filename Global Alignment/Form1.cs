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
                string temp = "";
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
    }
}

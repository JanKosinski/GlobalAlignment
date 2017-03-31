using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                //TODO Fasta File validation
                //TODO pozabezpieczac jak nie ma pliku itp itd
                string path = ofd.FileName;
                string temp = "";
                string text = System.IO.File.ReadAllText(path);
                Regex regex = new Regex(@">\S+\s+");
                Match match = regex.Match(text);
                string[] sequences = Regex.Split(text, @">\S+\s+");
                sequences = sequences.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                List<string> names = new List<string>();
                while (true)
                {
                    if (match.Success)
                    {
                        names.Add((match.Value).Trim());
                        match = match.NextMatch();
                    }
                    else
                    {
                        break;
                    }
                }
                if (names.Count != sequences.Length) {
                    Console.WriteLine("Wrong file format!");
                    return;
                }
                for (int j = 0; j< names.Count; j++){
                    this.dt.Rows.Add(new object[] { Regex.Replace(names[j], @"\s+", ""), Regex.Replace(sequences[j], @"\s+", "") });
                }


            }
            
        }
    }
}

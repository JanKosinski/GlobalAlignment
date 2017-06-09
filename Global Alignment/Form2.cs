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
    public partial class Form2 : Form
    {
        private Form1 form1 = null;
        public Form2(Form1 _form1)
        {
            InitializeComponent();
            form1 = _form1;
        }

        private void referenceSequenceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (referenceSequenceRadioButton.Checked) { randomSequenceRadioButton.Checked = false; seqLenNumericUpDown.Enabled = false; refSeqTextBox.Enabled = true; dnaCheckBox.Enabled = false; rnaCheckBox.Enabled = false; dnaCheckBox.Checked = false; rnaCheckBox.Checked = false; }
        }

        private void randomSequenceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (randomSequenceRadioButton.Checked) { referenceSequenceRadioButton.Checked = false; refSeqTextBox.Enabled = false;  seqLenNumericUpDown.Enabled = true; dnaCheckBox.Enabled = true; rnaCheckBox.Enabled = true; dnaCheckBox.Checked = true; }
        }

        private void form2_ok_Click(object sender, EventArgs e)
        {
            this.form1.dt.Rows.Clear();
            List<string> sequences = new List<string>();
            string type = "dna";
            if (dnaCheckBox.Checked)
            {
                type = "dna";
            }
            else {
                type = "rna";
            }
            int numberOfErrors = Convert.ToInt32(errorsNumUpDown.Value);
            int ord = 0;
            if (validateFields())
            {
                if (randomSequenceRadioButton.Checked)
                {
                    string randomSequence;
                    randomSequence = SharedMethods.randomNucleotideSequence(Convert.ToUInt32(seqLenNumericUpDown.Value) * 2, type);
                    sequences = InstanceGenerator.createInstance(randomSequence, Convert.ToUInt32(numberOfSequencesNumericUpDown.Value), Convert.ToUInt32(numberOfErrors), type);
                    for (int i = 0; i < sequences.Count; i++)
                    {
                        ord++;
                        this.form1.dt.Rows.Add(new object[] { "Sequence" + ord.ToString(), sequences[i] });
                    }

                }
                else {
                    if (refSeqTextBox.Text.Contains('U')) {
                        type = "rna";
                    }
                    else {
                        type = "dna";
                    }
                    sequences = InstanceGenerator.createInstance(refSeqTextBox.Text, Convert.ToUInt32(numberOfSequencesNumericUpDown.Value), Convert.ToUInt32(numberOfErrors), type);
                    for (int i = 0; i < sequences.Count; i++)
                    {
                        ord++;
                        this.form1.dt.Rows.Add(new object[] { "Sequence" + ord.ToString(), sequences[i] });
                    }
                }
                this.form1.Enabled = true;
                this.Close();
            }
            else { } 
        }

        private bool validateFields() {
            if (!referenceSequenceRadioButton.Checked && Convert.ToInt32(errorsNumUpDown.Value) >= (Convert.ToInt32(seqLenNumericUpDown.Value)/2)*Convert.ToInt32(numberOfSequencesNumericUpDown.Value)) {
                MessageBox.Show("Number of errors shuld be smaller than half of the sequence length multiplied by number of aligned sequences");
                return false;
            }
            if (referenceSequenceRadioButton.Checked && Convert.ToInt32(errorsNumUpDown.Value) >= ((refSeqTextBox.Text.Length/2) / 2) * Convert.ToInt32(numberOfSequencesNumericUpDown.Value))
            {
                MessageBox.Show("Number of errors shuld be smaller than half of the sequence length multiplied by number of aligned sequences");
                return false;
            }
            if (Convert.ToString(refSeqTextBox.Text).ToUpper().Contains("U") && Convert.ToString(refSeqTextBox.Text).ToUpper().Contains("T")) {
                MessageBox.Show("Reference sequence contains U and T");
                return false;
            }
            if (randomSequenceRadioButton.Checked) { return true; }
            else if (refSeqTextBox.Text.Length >= 10) {
                Regex sequenceRegex = new Regex(@"^[atgcuryswkmbdhvnATGCURYSWKMBDHVN\s]+$");
                Match match = sequenceRegex.Match(refSeqTextBox.Text);
                if (match.Value.ToString().Trim().Length == refSeqTextBox.Text.Trim().Length)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("You have entered invalid reference sequence!");
                    return false;
                }
            }
            MessageBox.Show("Your reference sequence should have at least 10 nucleotides");
            return false;
        }

        private void rnaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rnaCheckBox.Checked) {
                dnaCheckBox.Checked = false;
            }
        }

        private void dnaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (dnaCheckBox.Checked) {
                rnaCheckBox.Checked = false;
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.form1.Enabled = true;
        }
    }
}

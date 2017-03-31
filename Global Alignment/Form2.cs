using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (referenceSequenceRadioButton.Checked) { randomSequenceRadioButton.Checked = false; seqLenNumericUpDown.Enabled = false; refSeqTextBox.Enabled = true; }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (randomSequenceRadioButton.Checked) { referenceSequenceRadioButton.Checked = false; refSeqTextBox.Enabled = false;  seqLenNumericUpDown.Enabled = true; }
        }

        private void form2_ok_Click(object sender, EventArgs e)
        {
            Sequence seq;
            if (validateFields())
            {
                if (randomSequenceRadioButton.Checked) {
                    string randomSequence;
                    randomSequence = SharedMethods.randomNucleotideSequence(Convert.ToUInt32(seqLenNumericUpDown.Value)*2);
                    List<string> sequences = new List<string>();
                    sequences = InstanceGenerator.createInstance(randomSequence, Convert.ToUInt32(numberOfSequencesNumericUpDown.Value));
                    for (int i = 0; i < sequences.Count; i++) {
                        this.form1.dt.Rows.Add(new object[] { "change_me", sequences[i]});
                    }
                    
                }
                this.form1.Enabled = true;
                this.Close();
            }
            else { } //TODO change label color where condition is not fulfilled
        }

        private bool validateFields() {
            if (randomSequenceRadioButton.Checked) { return true; }
            else if (refSeqTextBox.Text.Length >= 10) { return true;   } // TODO and contains only IUPAC characters. Show warning when something is wrong
            return false;
        }
    }
}

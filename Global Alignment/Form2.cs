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
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

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
            if (validateFields())
            {
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

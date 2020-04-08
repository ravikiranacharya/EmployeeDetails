using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeDetails.Views
{
    public partial class Filter : Form
    {
        public int property; // To access the property from MainForm
        public String value; // To access the value from MainForm
        public Filter()
        {
            InitializeComponent();
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            comboBoxProperty.SelectedIndex = 0;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBoxProperty_SelectedIndexChanged(object sender, EventArgs e)
        {
            property = comboBoxProperty.SelectedIndex;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            value = textBox1.Text;
        }
    }
}

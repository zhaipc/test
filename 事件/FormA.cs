using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 事件
{
    public partial class FormA : Form
    {
        public FormA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormB formB = new FormB();
            formB.Set += SetTxt;
            formB.Show();

        }
        private void SetTxt(string txt)
        {
            textBox1.Text = txt;
        }

    }
}

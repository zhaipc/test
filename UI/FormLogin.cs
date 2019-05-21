using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Managerinfo managerinfo = new Managerinfo
            {
                Mname = textBox1.Text.Trim(),
                Mpwd = textBox2.Text.Trim()
            };
            managerinfobll managerinfobll = new managerinfobll();
            if( managerinfobll.Login(managerinfo))
            {
                MainForm mainForm = new MainForm();
                mainForm.Tag = managerinfo.MType;
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("失败");
            }
        }
    }
}

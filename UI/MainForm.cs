using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if(this.Tag.ToString()=="1")
            {
                managerToolStripMenuItem.Visible = false;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void managerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Managerinfolist managerinfolist = new Managerinfolist();
            managerinfolist.Show();
        }

        private void 数量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MemberInfolist member = new MemberInfolist();
            member.Show();
        }
    }
}

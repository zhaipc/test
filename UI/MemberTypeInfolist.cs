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
using Model;

namespace UI
{
    public partial class MemberTypeInfolist : Form
    {
        private MemberTypeInfolist()
        {
            InitializeComponent();
        }

        private static MemberTypeInfolist memberType;
        public static MemberTypeInfolist Creat()
        {
            if (memberType == null)
            {
                memberType = new MemberTypeInfolist();
            }
            return memberType;
        }
        Membertypeinfobll mb = new Membertypeinfobll();
        private void MemberTypeInfolist_Load(object sender, EventArgs e)
        {
            LoadDate();
        }
        public void LoadDate()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = mb.GetList();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Membertypeinfo mi = new Membertypeinfo()
            {
                Mtitle = txtname.Text.Trim(),
                Mdiscount = Convert.ToDecimal(txtpwd.Text.Trim())
            };
            if(btnSave.Text.Equals("添加"))
            {
                if (mb.AddList(mi))
                {
                    LoadDate();
                    btnmiss_Click(null, null);
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            else
            {
                mi.Mid = Convert.ToInt32(textBox1.Text.Trim());
                if( mb.UpdateList(mi))
                {
                    LoadDate();
                    btnmiss_Click(null, null);
                }
                else
                {
                    MessageBox.Show("失败");
                }
            }
            
        }

        private void btnmiss_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtpwd.Clear();
            btnSave.Text = "添加";
            textBox1.Text = "添加时无编号";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            txtname.Text = row.Cells[1].Value.ToString();
            txtpwd.Text = row.Cells[2].Value.ToString();
            btnSave.Text = "保存";
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.SelectedRows;
            if(row.Count>0)
            {
                DialogResult result = MessageBox.Show("确定要删除吗？", "删除提示", MessageBoxButtons.YesNo);
                if(result==DialogResult.Yes)
                {
                    int id = Convert.ToInt32(row[0].Cells[0].Value.ToString());
                    Membertypeinfo mi = new Membertypeinfo
                    {
                        Mid = id
                    };
                   if( mb.DeleteList(mi))
                    {
                        LoadDate();
                        btnmiss_Click(null, null);
                    }
                   else
                    {
                        MessageBox.Show("失败");
                    }
                }
            }
        }

        private void MemberTypeInfolist_FormClosing(object sender, FormClosingEventArgs e)
        {
            memberType = null;
        }
    }
}

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
    public partial class MemberInfolist : Form
    {
        public MemberInfolist()
        {
            InitializeComponent();
        }
       
        private void MemberInfolist_Load(object sender, EventArgs e)
        {
            LoadDate();
            LoadList();
        }
        MemberinfoBll mb = new MemberinfoBll();
        public void LoadDate()
        {
            MemberInfo mi = new MemberInfo()
            {
                MName = textBox2.Text,
                MPhone = textBox3.Text
            };
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = mb.GetList(mi);
        }
        public void LoadList()
        {
            Membertypeinfobll mb = new Membertypeinfobll();
            List<Membertypeinfo> list = mb.GetList();
            comboBox1.DisplayMember = "MTitle";
            comboBox1.ValueMember = "MId";
            comboBox1.DataSource = list;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(btnSave.Text.Equals("添加"))
            {
               bool s= mb.Addlist(new MemberInfo() {
                    MIsDelete = Convert.ToBoolean(0),
                    MMoney = Convert.ToDecimal(textBox5.Text.Trim()),
                    MName = txtname.Text.Trim(),
                    MPhone = textBox4.Text.Trim(),
                    MTypeId = Convert.ToInt32(comboBox1.SelectedValue)
                });
                if(s)
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
                bool s = mb.Updatelist(new MemberInfo()
                {
                    MIsDelete = Convert.ToBoolean(0),
                    MMoney = Convert.ToDecimal(textBox5.Text.Trim()),
                    MName = txtname.Text.Trim(),
                    MPhone = textBox4.Text.Trim(),
                    MTypeId = Convert.ToInt32(comboBox1.SelectedValue),
                    MId=Convert.ToInt32(textBox1.Text)
                });
                if (s)
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
            textBox1.Text = "添加时无编号";
            txtname.Clear();
            comboBox1.SelectedIndex = 0;
            textBox4.Clear();
            textBox5.Clear();
            btnSave.Text = "添加";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            txtname.Text = row.Cells[1].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            comboBox1.Text = row.Cells[2].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.SelectedRows;
            if(row.Count>0)
            {
                DialogResult result = MessageBox.Show("确定删除吗？", "消息提醒", MessageBoxButtons.YesNo);
                if(result==DialogResult.Yes)
                {
                    int s = Convert.ToInt32(row[0].Cells[0].Value.ToString());
                    MemberInfo memberInfo = new MemberInfo()
                    {
                        MId = s
                    };
                    if(mb.Delete(memberInfo))
                    {
                        LoadDate();
                       
                    }
                    else
                    {
                        MessageBox.Show("失败");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox3.Clear();
            LoadDate();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            LoadDate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemberTypeInfolist we = MemberTypeInfolist.Creat();
            we.Show();
            we.Activate();
            we.Focus();
        }
    }
}

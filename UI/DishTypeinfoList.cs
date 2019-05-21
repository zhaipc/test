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
    public partial class DishTypeinfoList : Form
    {
        public DishTypeinfoList()
        {
            InitializeComponent();
        }
        DishtypeinfoBll db = new DishtypeinfoBll();
        private void DishTypeinfoList_Load(object sender, EventArgs e)
        {
            LoadDate();
        }
        public void LoadDate()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = db.Getlist();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DishTypeInfo di = new DishTypeInfo();
            di.DTitle = txtname.Text;
            if(btnSave.Text.Equals("添加"))
            {
               if( db.Addlist(di))
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
                di.DId = Convert.ToInt32(textBox1.Text.Trim());
                if(db.Updatelist(di))
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
            btnSave.Text = "添加";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            txtname.Text = row.Cells[1].Value.ToString();
            btnSave.Text = "修改";
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            DishTypeInfo di = new DishTypeInfo();
            var row = dataGridView1.SelectedRows;
            if(row.Count>0)
            {
                DialogResult result = MessageBox.Show("确定删除吗？", "消息提醒", MessageBoxButtons.YesNo);
                if(result==DialogResult.Yes)
                {
                    di.DId = Convert.ToInt32(row[0].Cells[0].Value.ToString());
                   if(db.Deletelist(di))
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
    }
}

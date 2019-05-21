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
using Common;

namespace UI
{
    public partial class Managerinfolist : Form
    {
        public Managerinfolist()
        {
            InitializeComponent();
        }
        managerinfobll mibll = new managerinfobll();
        private void Managerinfo_Load(object sender, EventArgs e)
        {
           
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = mibll.Getlist();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if( e.ColumnIndex==2)
            {
                switch(e.Value.ToString())
                {
                    case "1":e.Value = "店员";break;
                    case "0":e.Value = "经理";break;
                }
            }
           
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool w=false;
            //MD5Helper mD5 = new MD5Helper();
            Managerinfo managerinfo = new Managerinfo() {
                MId=Convert.ToInt32( textBox1.Text.Trim()),
                Mname = txtname.Text.Trim(),
                Mpwd = txtpwd.Text,
                MType = type0.Checked ? 0 : 1
            };
            if (btnSave.Text == "添加")
            {
                 w = mibll.Addlist(managerinfo);
            }
            if(btnSave.Text == "保存")
            {
                w = mibll.UpdateList(managerinfo);
            }
            if(w)
            {
                //MessageBox.Show("插入成功");
                dataGridView1.DataSource = mibll.Getlist();
            }
            else
            {
                MessageBox.Show("插入失败！");
                btnmiss_Click(null, null);
            }

        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnmiss_Click(object sender, EventArgs e)
        {
            txtname.Clear();
            txtpwd.Clear();
            type1.Checked = true;
            textBox1.Text = "添加时无编号";
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btndel_Click(object sender, EventArgs e)
        {
          
            var rows = dataGridView1.SelectedRows;
            if(rows.Count>0)
            {
                int s = Convert.ToInt32(rows[0].Cells[0].Value);
                DialogResult result = MessageBox.Show("确定删除吗？", "消息提醒", MessageBoxButtons.YesNo);
               if(result==DialogResult.Yes)
                {
                    if ( mibll.dellist(s))
                    {
                        dataGridView1.DataSource = mibll.Getlist();
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
               else
                {
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("没选中");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            textBox1.Text = row.Cells[0].Value.ToString();
            txtname.Text = row.Cells[1].Value.ToString();
            txtpwd.Text = "********";
            if(row.Cells[2].Value.ToString()=="1")
            {
                type1.Checked = true;
            }
            else
            {
                type0.Checked = true;
            }
            btnSave.Text = "保存";
        }
    }
}

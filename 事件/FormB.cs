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
    public partial class FormB : Form
    {
        public FormB()
        {
            InitializeComponent();
        }
        public event Action<string> Set;
            //Action<T> 无返回值的委托类型
           // Func<T>  有返回值的委托类型
        private void button1_Click(object sender, EventArgs e)
        {
            Set(textBox1.Text);
        }
    }
}

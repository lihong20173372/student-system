using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Student
{
    public partial class 学生管理信息系统 : Form
    {
        public 学生管理信息系统()
        {
            InitializeComponent();
        }

        private void 学生信息管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 课程管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void 系统管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            f.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 重新登陆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            f.Show();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }

        private void 查找ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.Show();
        }

        private void 修改ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
        }
    }
}

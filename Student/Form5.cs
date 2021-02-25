using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            string password = textBox3.Text;
            string conn = "Data source=.;initial catalog=Student;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conn);
            if (id == "" || password == "")
            {
                MessageBox.Show("请输入完整信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = String.Format("insert into Login(UserID,UserName,Password) values('{0}',{1}',{2}')",id,name,password);
                try
                {
                    connection.Open();
                    SqlCommand comm = new SqlCommand(sql, connection);
                    int count = comm.ExecuteNonQuery();
                    if (count > 0)
                        MessageBox.Show("添加信息成功", "添加成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("添加信息失败", "添加失败", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                finally
                {
                    connection.Close();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

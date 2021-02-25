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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserID = txtID.Text.Trim();
            string Password = txtPwd.Text.Trim();
            string connString = "Data Source=.;Initial Catalog=Student;Integrated security=True";
            SqlConnection conn = new SqlConnection(connString);
            string sql = string.Format("select count(*) from Login where UserID ='{0}' and Password='{1}'", UserID, Password);
            try
            {
                conn.Open();
                SqlCommand comm = new SqlCommand(sql, conn);
                int num = (int)comm.ExecuteScalar();
                if (num == 1)
                {
                    MessageBox.Show("欢迎进入学生管理系统！", "登陆成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    学生管理信息系统 f2 = new 学生管理信息系统();
                    f2.Show();
                    this.Visible = false;
                }


                else
                {
                    txtPwd.Text = "";
                    MessageBox.Show("您输入的用户名或密码错误！", "登陆失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作数据库出错！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtPwd.Text = "";
            txtID.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

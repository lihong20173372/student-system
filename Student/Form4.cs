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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
       
        private void Form4_Load(object sender, EventArgs e)
        {
            string conn = "data source=.;initial catalog=Course;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string sql = "select * from Course";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet data = new DataSet();
            adapter.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedCells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedCells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string course1= textBox1.Text;
            string course2 = textBox2.Text;
            string course3= textBox3.Text;
            string course4= textBox4.Text;
            string conn = "Data source=.;initial catalog=Student;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conn);

            if (course1 == "" || course2 == "" || course3 == "" || course4 == "")
            {
                MessageBox.Show("请输入完整信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
            }
            else 
            { 
                string sql = String.Format("insert into Course(课程号, 课程名称, 学时,学分) values('{0}','{1}','{2}','{3}')", course1, course2, course3, course4);
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
            string course1 = textBox1.Text;
            string course2 = textBox2.Text;
            string course3 = textBox3.Text;
            string course4 = textBox4.Text;
            string conn = "data source=.;initial catalog=Student;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conn);

            string sql = String.Format("update Course set 学分='{0}' where 课程号='{1}'", course4, course1);
            try
            {
                connection.Open();
                SqlCommand comm = new SqlCommand(sql, connection);
                int count = comm.ExecuteNonQuery();
                if (count > 0)
                    MessageBox.Show("更新信息成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("更新信息失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                connection.Close();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string course1 = textBox1.Text;
            string conn = "data source=.;initial catalog=Student;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conn);

            string sql = String.Format("delete from Course where 课程号='{0}'", course1);
            try
            {
                connection.Open();
                SqlCommand comm = new SqlCommand(sql, connection);
                int count = comm.ExecuteNonQuery();
                if (count > 0)
                    MessageBox.Show("删除信息成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("删除信息失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

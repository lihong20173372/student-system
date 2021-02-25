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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        DataSet ds;
        private void Form6_Load(object sender, EventArgs e)
        {
            String str = "Data Source=.;Initial Catalog=Student;Integrated security=True";
            conn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("select * from Login", conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds, "user");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Login", conn);
            SqlCommandBuilder buider = new SqlCommandBuilder(da);
            da.Fill(ds, "Login");
            DataRow dr = ds.Tables["Login"].NewRow();
            dr["UserID"] = textBox1.Text.Trim();
            dr["Password"] = textBox2.Text.Trim();
            ds.Tables["Login"].Rows.Add(dr);
            da.Update(ds, "Login");
            conn.Close();
            MessageBox.Show("注册用户" + textBox1.Text.Trim() + "成功");
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}

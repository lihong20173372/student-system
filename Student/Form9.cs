﻿using System;
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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conn = "data source=.;initial catalog=Student;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string sql = "select * from Course";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet data = new DataSet();
            adapter.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sno = textBox1.Text;
            string conn = "data source=.;initial catalog=Student;Integrated Security=True";
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            string sql = string.Format("select * from Course where 课程名称='{0}'", sno);
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet data = new DataSet();
            adapter.Fill(data);
            dataGridView1.DataSource = data.Tables[0];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

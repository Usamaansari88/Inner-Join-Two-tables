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

namespace inner_join
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }
        string con = "Data Source=DESKTOP-UR1SGFT\\SQLEXPRESS;Initial Catalog=Students;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(con);
            c.Open();

            string query = " Select stdinfo.RollNo,stdinfo.Name,stdinfo.Class,stdinfo.Section,stdmarks.Subject1,stdmarks.Subject2,stdmarks.Subject3,stdmarks.Subject4 from stdinfo inner join stdmarks on stdinfo.RollNo=stdmarks.RollNo where stdinfo.RollNo='"+textBox1.Text.ToString()+"'";

            SqlCommand cmd = new SqlCommand(query, c);
            cmd.ExecuteNonQuery();

            DataTable data = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(data);
            dataGridView1.DataSource = data;
            c.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

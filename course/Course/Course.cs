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

namespace Course
{
    public partial class Course : Form
    {
        public int p;
        public String name;
        SqlCommand com;
        SqlDataReader dr;

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=Course;Integrated Security=True");
        public Course()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            com = new SqlCommand("SELECT * FROM Item WHERE Id= " + int.Parse(textBox2.Text), con);
            dr = com.ExecuteReader();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you..");
        }
    }
}

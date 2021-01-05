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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlCommand com;

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=Course;Integrated Security=True");

        Admin admin = new Admin();
        private void Employee_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {

                com = new SqlCommand("INSERT INTO SignUp (ID,Name,password,mail,Phonenumber,UserType) values (@ID,@Name,@password,@mail,@Phonenumber,@UserType)", con);

                com.Parameters.AddWithValue("@ID", this.textBox2.Text.ToString());
                com.Parameters.AddWithValue("@Name", this.textBox1.Text);
                com.Parameters.AddWithValue("@password", this.textBox3.Text);
                com.Parameters.AddWithValue("@mail", this.textBox4.Text);
                com.Parameters.AddWithValue("@Phonenumber", this.textBox5.Text);
                com.Parameters.AddWithValue("@UserType", this.comboBox2.SelectedItem.ToString());
                com.ExecuteNonQuery();
                MessageBox.Show("Info Added");

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

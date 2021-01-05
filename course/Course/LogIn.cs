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
    public partial class LogIn : Form
    {
        SqlCommand com;
        SqlDataAdapter da;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=Course;Integrated Security=True");
        public LogIn()
        {
            InitializeComponent();
        }

        private void SignIn_Click(object sender, EventArgs e)
        {

            con.Close();

            String aid = Convert.ToString(NameSI.Text);
            con.Open();
            com = new SqlCommand("SELECT * FROM SignUp WHERE Id= '" + NameSI.Text.ToString() + "'and Password='" + PassSI.Text.ToString() + "'", con);
            da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataReader dr = com.ExecuteReader();
            if (dt.Rows.Count > 0)
            {
                con.Close();
                con.Open();
                SqlCommand com = new SqlCommand("SELECT * FROM SignUp WHERE Id= " + int.Parse(NameSI.Text), con);

                dr = com.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Your Id is found");
                }

                else
                {
                    MessageBox.Show("Your Id is not found");
                }
            }
        }
                    
    }
}

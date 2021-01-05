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
    public partial class Admin : Form
    {

        public String ind;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-F9IRGFB;Initial Catalog=Course;Integrated Security=True");
        public void Remonve()
        {
            try
            {
                if (ind == null)
                {
                    MessageBox.Show("Not selected");
                }

                else
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("DELETE FROM SignUp WHERE id= '" + int.Parse(ind) + "'", con);
                    com.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                Close();
            }
        }
        public Admin()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Remonve();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ind = dataGridView2.Rows[e.RowIndex].Cells["Id"].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = null;
            DataTable dt1 = new DataTable();
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM SignUp ", con);

            da.Fill(dt1);
            dataGridView2.DataSource = dt1;
            con.Close();
        }
    }
}

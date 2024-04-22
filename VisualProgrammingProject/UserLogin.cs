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

namespace VisualProgrammingProject
{
    public partial class UserLogin : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dinca\source\repos\VisualProgrammingProject\VisualProgrammingProject\VisualProgramming.mdf;Integrated Security=True");
        public UserLogin()
        {
            InitializeComponent();
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UserLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Users where UserName= '" + textBox2.Text + "' and Password ='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("This username or password is incorrect");
                }
                else
                {
                    this.Hide();
                    Orders orders = new Orders(false);
                    orders.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
        }

        private void signUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddNewUser addNewUser = new AddNewUser(false);
            addNewUser.Show();
        }

        private void adminLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            AdminLogin adminLogin = new AdminLogin();   
            adminLogin.Show();
        }
    }
}

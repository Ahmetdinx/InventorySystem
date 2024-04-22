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
    public partial class AddNewUser : Form
    {
        public bool isAdmin { get; set; }

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dinca\source\repos\VisualProgrammingProject\VisualProgrammingProject\VisualProgramming.mdf;Integrated Security=True");
        public AddNewUser(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;
        }

        
        private void AddNewUser_Load(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
            Display();
        }

        private void addNewUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox3.Text)) 
                {
                    MessageBox.Show("Please enter a username.");
                    return; 
                }

                if (string.IsNullOrEmpty(textBox4.Text)) 
                {
                    MessageBox.Show("Please enter a password.");
                    return; 
                }

                int i = 0;
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Users where UserName= '" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    try
                    {
                        SqlCommand cmd1 = connection.CreateCommand();
                        cmd1.CommandType = CommandType.Text;
                        cmd1.CommandText = "insert into Users values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "', '" + isAdmin.ToString() + "')";
                        cmd1.ExecuteNonQuery();

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        Display();

                        MessageBox.Show("User added successfully");
                        this.Hide();
                        if (isAdmin)
                        {
                            AdminLogin login = new AdminLogin();
                            login.Show();
                        }
                        else
                        {
                            UserLogin login = new UserLogin();
                            login.Show();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while adding the user: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("This username is already registered. Please choose another one.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void login_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserLogin login = new UserLogin();
            login.Show();
        }

        public void Display()
        {
            int i = 0;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Users  ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deleteUser_Click(object sender, EventArgs e)
        {
            int id;
            id = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString()); 
            SqlCommand command = connection.CreateCommand();    
            command.CommandType = CommandType.Text;
            command.CommandText = "delete from Users where id = " + id + "";
            command.ExecuteNonQuery();
            Display();
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
    }

}

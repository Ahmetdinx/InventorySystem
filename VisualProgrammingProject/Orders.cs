using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace VisualProgrammingProject
{
    public partial class Orders : Form
    {
      

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dinca\source\repos\VisualProgrammingProject\VisualProgrammingProject\VisualProgramming.mdf;Integrated Security=True");

        public Orders(bool isAdmin)
        {
            
            InitializeComponent();
            if (!isAdmin)
            {
                backToMenu.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Orders_Load(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            connection.Open();
            Display();
           
        }
        public void Display()
        {
            int i = 0;
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Orders  ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            FillProductName();
        }
        public void FillProductName()
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from  Products";
            cmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();  
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                comboBox1.Items.Add(dataRow["ProductName"].ToString()); 
            }
        }

        private void backToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserLogin login = new UserLogin();
            login.Show();
        }

        private void order_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text)) 
            {
                MessageBox.Show("Please enter quantity.");
                return; 
            }

            if (string.IsNullOrEmpty(comboBox1.Text)) 
            {
                MessageBox.Show("Please enter a product name.");
                return; 
            }

            if (dateTimePicker1.Value == DateTime.MinValue) 
            {
                MessageBox.Show("Please select a valid date.");
                return; 
            }


            SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "insert into Orders values('" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.ToString("dd-mm-yyyy") + "')";
                cmd2.ExecuteNonQuery();
                

                Display();

                MessageBox.Show("Order added successfully");
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Products where ProductName = '" + comboBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            dataAdapter.Fill(dt);
            foreach (DataRow dataRow in dt.Rows)
            {
                comboBox1.Items.Add(dataRow["ProductName"].ToString());
            }
        }

        public void UpdateStockQuantity(int productId , int warehouseId , int factoryId , int quantity) 
        {

        }
    }
}

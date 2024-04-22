using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualProgrammingProject
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void products_Click(object sender, EventArgs e)
        {
            this.Hide();
            Products products = new Products();
            products.Show();
        }

        private void manufacturingFactories_Click(object sender, EventArgs e)
        {
            this.Hide();
            ManufacturingFactories manufacturingFactories = new ManufacturingFactories();
            manufacturingFactories.Show();
        }

        

        private void warehouses_Click(object sender, EventArgs e)
        {
            this.Hide();
            Warehouses warehouses = new Warehouses();
            warehouses.Show();
        }

        private void addNewUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddNewUser addNewUser = new AddNewUser(true);
            addNewUser.Show();
         
        }

        private void orders_Click(object sender, EventArgs e)
        {
            this.Hide();
            Orders orders = new Orders(true);
            orders.Show();
        }

        private void AdminLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin login = new AdminLogin();
            login.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Credits credits = new Credits(); 
            credits.Show();
        }

        private void contactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contact contact = new Contact();
            contact.Show();
        }

        
    }
}

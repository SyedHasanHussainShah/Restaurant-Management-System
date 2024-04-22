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
namespace project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leverage\Downloads\rdb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static string User;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            User = username.Text;
          if(username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Please Enter Username or Password");
            }
            else
            {
                con.Open();
                SqlDataAdapter sa = new SqlDataAdapter("select count(*) from UserTable where Uname = '"+username.Text+"'and Upassword ='"+password.Text+"'",con);
                DataTable d = new DataTable();
                sa.Fill(d);
                if (d.Rows[0][0].ToString() == "1")
                {
                    Main a = new Main();
                    a.Show();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }
                con.Close();
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2CirclePictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

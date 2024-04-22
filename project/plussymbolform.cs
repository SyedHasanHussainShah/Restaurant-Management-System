using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace project
{
    public partial class plussymbolform : Form
    {
        public plussymbolform()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leverage\Downloads\rdb.mdf;Integrated Security=True;Connect Timeout=30");
        void popluate()
        {
            con.Open();
            string query = "select * from Itemtable";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder s = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView4.DataSource = ds.Tables[0];
            con.Close();
        }
        private void plussymbolform_Load(object sender, EventArgs e)
        {
            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font("Times new roman", 16, FontStyle.Bold);
            popluate();
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            itemsform a = new itemsform();
            a.Show();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main a = new Main();
            a.Show();
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            itemnum.Text = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
            itemname.Text = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
            catcb.Text = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
            itemprice.Text = dataGridView4.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 a = new Form2();
            a.Show();
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            userplussymbol a = new userplussymbol();
            a.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Menu a = new Menu();
            a.Show();
        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Main a = new Main();
            a.Show();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            plussymbolform a = new plussymbolform();
            a.Show();
        }

        private void guna2GradientButton6_Click_1(object sender, EventArgs e)
        {
            Menu a = new Menu();
            a.Show();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            userplussymbol a = new userplussymbol();
            this.Hide();
            a.Show();
        }

        private void guna2GradientButton7_Click_1(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestOrder a = new GuestOrder();
            a.Show();
        }
    }
}

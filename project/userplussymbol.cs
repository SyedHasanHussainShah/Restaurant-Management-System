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

namespace project
{
    public partial class userplussymbol : Form
    {
        public userplussymbol()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leverage\Downloads\rdb.mdf;Integrated Security=True;Connect Timeout=30");
        void popluate()
        {
            con.Open();
            string query = "select * from UserTable";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder s = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            usergridview.DataSource = ds.Tables[0];
            con.Close();
        }

        private void userplussymbol_Load(object sender, EventArgs e)
        {
            usergridview.EnableHeadersVisualStyles = false;
            usergridview.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            usergridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            usergridview.ColumnHeadersDefaultCellStyle.Font = new Font("Times new roman", 16, FontStyle.Bold);
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            userform a = new userform();
            a.Show();
        }

        private void usergridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            uname.Text = usergridview.SelectedRows[0].Cells[0].Value.ToString();
            uphone.Text = usergridview.SelectedRows[0].Cells[0].Value.ToString();
            upass.Text = usergridview.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            popluate();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            plussymbolform a = new plussymbolform();
            a.Show();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 a = new Form2();
            a.ShowDialog();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Main a = new Main();
            this.Hide();
            a.ShowDialog();
        }

        private void guna2GradientButton4_Click_1(object sender, EventArgs e)
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

        private void guna2GradientButton6_Click(object sender, EventArgs e)
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

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
        }

        private void guna2GradientButton5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            GuestOrder a = new GuestOrder();
            a.Show();
        }
    }
}

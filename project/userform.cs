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
using System.Security.Cryptography.X509Certificates;
namespace project
{
    public partial class userform : Form
    {
        public userform()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leverage\Downloads\rdb.mdf;Integrated Security=True;Connect Timeout=30");
        void popluate()
        {
            con.Open();
            string query = "select * from UserTable";
            SqlDataAdapter adapter = new SqlDataAdapter(query,con);
            SqlCommandBuilder s = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            usergridview.DataSource = ds.Tables[0];
            con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            userplussymbol a = new userplussymbol();
            a.Show();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            itemsform a = new itemsform();
            a.Show();
        }

        private void add_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "insert into UserTable values('"+uname.Text+"','"+uphone.Text+"','"+upass.Text+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("User Successfully created");
            con.Close();
            popluate();
            reset();
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            popluate();
        }

        //private void usergridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    uname.Text = usergridview.SelectedRows[0].Cells[0].Value.ToString();
        //    uphone.Text = usergridview.SelectedRows[0].Cells[0].Value.ToString();
        //    upass.Text = usergridview.SelectedRows[0].Cells[0].Value.ToString();
        //}
        private void del_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "DELETE FROM UserTable WHERE Uphone = @Uphone";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Uphone", uphone.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully deleted");
                con.Close();
                popluate();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void Editbtn_Click(object sender, EventArgs e)
        {
            if(uname.Text == ""|| uphone.Text == "" || upass.Text == "")
            {
                MessageBox.Show("Fill all the fields");
            }
            else
            {
                con.Open();
                string query = "update UserTable set Uname = '" + uname.Text + "',Upassword='" + upass.Text + "'where Uphone ='" + uphone.Text + "'";
                SqlCommand sql = new SqlCommand(query, con);
                sql.ExecuteNonQuery();
                MessageBox.Show("User updated Successfully");
                con.Close();   
                popluate();
                reset();
            }
        }
        public void reset()
        {
            uname.Text = "";
            uphone.Text = "";
            upass.Text = "";
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usergridview_CellContentClick(object sender, EventArgs e)
        {
            uname.Text = usergridview.SelectedRows[0].Cells[0].Value.ToString();
            uphone.Text = usergridview.SelectedRows[0].Cells[0].Value.ToString();
            upass.Text = usergridview.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 a = new Form2();
            a.ShowDialog();
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void userform_Load(object sender, EventArgs e)
        {
            usergridview.EnableHeadersVisualStyles = false;
            usergridview.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            usergridview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            usergridview.ColumnHeadersDefaultCellStyle.Font = new Font("Times new roman", 16, FontStyle.Bold);
           
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

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
    }
}

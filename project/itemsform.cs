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
    public partial class itemsform : Form
    {
        public itemsform()
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
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            this.Hide();
            plussymbolform a = new plussymbolform();
            a.Show();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            userform a = new userform();
            a.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //add wala
        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            if (itemnum.Text == "" || itemname.Text == "" || itemprice.Text == "")
            {
                MessageBox.Show("Fill All The Fields");
            }
            else
            {
                con.Open();
                string query = "insert into ItemTable values(" + itemnum.Text + ",'" + itemname.Text + "','" + catcb.SelectedItem.ToString() + "'," + itemprice.Text + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Successfully created");
                con.Close();
                popluate();
                reset();
            }
        }

        private void itemsform_Load(object sender, EventArgs e)
        {
            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView4.ColumnHeadersDefaultCellStyle.Font = new Font("Times new roman", 16, FontStyle.Bold);
            popluate();
            any();
        }
        //del wala
        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "delete from ItemTable where ItemNum ='" + itemnum.Text + "';";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Item Succesfully del ");
                con.Close();
                popluate();
                reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void reset()
        {
            itemnum.Text = "";
            itemname.Text = "";
            catcb.SelectedItem = "";
            itemprice.Text = "";
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void dataGridView4_CellContentClick(object sender, EventArgs e)
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

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Menu a = new Menu();
            a.Show();
        }
        public void any()
        {
            string ordem;
            string query = "select ItemNum from ItemTable order by ItemNum desc";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                int num = int.Parse(dr[0].ToString()) + 1;
                ordem = num.ToString();
            }
            else if (Convert.IsDBNull(dr))
            {
                ordem = "0";
            }
            else
            {
                ordem = "1";
            }
            con.Close();
            itemnum.Text = ordem.ToString();

        }
    }
}



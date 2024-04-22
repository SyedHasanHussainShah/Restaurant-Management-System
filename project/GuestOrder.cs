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
    public partial class GuestOrder : Form
    {
        public GuestOrder()
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
            Guestview.DataSource = ds.Tables[0];
            con.Close();
        }
        void filterbycatagery()
        {
            con.Open();
            string query = "select * from Itemtable where ItemCat = '" +catcb.SelectedItem.ToString()+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder s = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            Guestview.DataSource = ds.Tables[0];
            con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void any()
        {
            string ordem;
            string query = "select OrderNum from OrderTable order by OrderNum desc";
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
            Ordernum.Text = ordem.ToString();

        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main a = new Main();
            a.Show();
        }
        int num = 0;
        int total, price;
        string ite,cat;

        private void Addtochart_Click(object sender, EventArgs e)
        {
            if(quantity.Text == "")
            {
                MessageBox.Show("Plz fill the quantity box");
            }
            else if(flag == 0)
            { 
                MessageBox.Show("Select the product to be ordered ");
            }
            else
            {
                num = num + 1;
                total = price * Convert.ToInt32(quantity.Text);
                db.Rows.Add(num,ite,cat,price,total);
                guestorderGv.DataSource = db;
                flag = 0;
            }
            sum = sum + total;
            Orderedamt.Text = "" + sum;

        }
        DataTable db = new DataTable();

        private void catcb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            filterbycatagery();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            popluate();
        }

        private void Date_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Guestview_CellContentClick(object sender, EventArgs e)
        {
            ite = Guestview.SelectedRows[0].Cells[1].Value.ToString();
            cat = Guestview.SelectedRows[0].Cells[2].Value.ToString();
            price = Convert.ToInt32(Guestview.SelectedRows[0].Cells[3].Value.ToString());
            flag = 1;
        }

        int flag = 0;

        private void quantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guestview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void placeorder_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "insert into OrderTable values('" + Ordernum.Text + "','" + Date.Text + "','" + Sellername.Text + "'," + Orderedamt.Text + ")";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Order Successfully created");
            con.Close();
            //popluate();
           // reset();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            GuestMenu a = new GuestMenu();
            a.Show();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestOrder a = new GuestOrder();
            a.Show();
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {

            Form2 a = new Form2();
            a.Show();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            userplussymbol a = new userplussymbol();
            this.Hide();
            a.Show();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            Menu a = new Menu();
            a.Show();
        }

        private void guna2GradientButton3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            plussymbolform a = new plussymbolform();
            a.Show();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main a = new Main();
            a.Show();
        }

        int sum = 0;
        private void GuestOrder_Load(object sender, EventArgs e)
        {
            any();
            popluate();
            db.Columns.Add("Num", typeof(int));
            db.Columns.Add("item", typeof(string));
            db.Columns.Add("Category", typeof(string));
            db.Columns.Add("UnitPrice", typeof(int));
            db.Columns.Add("Total", typeof(int));
            guestorderGv.DataSource = db;
            Date.Text = DateTime.Now.ToString() + "/" + DateTime.Now.Year.ToString();
            Guestview.EnableHeadersVisualStyles = false;
            Guestview.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            Guestview.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            Guestview.ColumnHeadersDefaultCellStyle.Font = new Font("Times new roman", 16, FontStyle.Bold);
            guestorderGv.EnableHeadersVisualStyles = false;
            guestorderGv.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            guestorderGv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            guestorderGv.ColumnHeadersDefaultCellStyle.Font = new Font("Times new roman", 16, FontStyle.Bold);
        }
    }
}

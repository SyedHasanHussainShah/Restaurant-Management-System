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
    public partial class viewlist : Form
    {
        public viewlist()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leverage\Downloads\rdb.mdf;Integrated Security=True;Connect Timeout=30");
        void popluate()
        {
            con.Open();
            string query = "select * from OrderTable";
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder s = new SqlCommandBuilder(adapter);
            var ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        
        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ListGv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void viewlist_Load(object sender, EventArgs e)
        {
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkSlateBlue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Times new roman", 12, FontStyle.Bold);
            popluate();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Title
            e.Graphics.DrawString("____*******HR Restaurant*****_____", new Font("Arial", 26, FontStyle.Bold), Brushes.Red, new Point(150, 50));
            // Orders Details
            e.Graphics.DrawString("____*******Orders Details******_____", new Font("Arial", 20, FontStyle.Bold), Brushes.Blue, new Point(180, 90));
            // Order Number
            e.Graphics.DrawString("Order NO:  " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString(), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 130));
            // Order Date
            e.Graphics.DrawString("Order Date-Time:  " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString(), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 160));
            // Seller Name
            e.Graphics.DrawString("Seller Name:   " + dataGridView1.SelectedRows[0].Cells[2].Value.ToString(), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 190));
            // Order Amount
            e.Graphics.DrawString("Order Amount:  " + dataGridView1.SelectedRows[0].Cells[3].Value.ToString(), new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(100, 220));
            // Thanks message
            e.Graphics.DrawString("____*******Thanks For Coming******_____", new Font("Arial", 20, FontStyle.Bold), Brushes.Green, new Point(180, 250));
            // Claim information
            e.Graphics.DrawString("____*******If any claims, inform our team within three days******_____", new Font("Arial", 14, FontStyle.Bold), Brushes.Black, new Point(80, 280));
            // FBR Verification
            e.Graphics.DrawString("____*******FBR Verified******_____", new Font("Arial", 20, FontStyle.Bold), Brushes.Red, new Point(180, 310));

        }
    }
}

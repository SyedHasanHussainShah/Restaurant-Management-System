using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
namespace project
{
    public partial class Main : Form
    {
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Main()
        {
            InitializeComponent();
            player.URL = "music.mp3";
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Main a = new Main();
            this.Hide();
            a.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
           
            plussymbolform a = new plussymbolform();
            this.Hide();
            a.Show();
            player.controls.stop();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            userplussymbol a = new userplussymbol();
            this.Hide();
            a.Show();
            player.controls.stop();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
            player.controls.stop();
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            a.Show();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            this.Hide();
            GuestOrder a = new GuestOrder();
            a.Show();
            player.controls.stop();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            Menu a = new Menu();
            a.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            player.controls.play();
        }
    }
}

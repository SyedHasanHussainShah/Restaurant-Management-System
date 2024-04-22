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
    public partial class Loadcs : Form
    {
        WindowsMediaPlayer b = new WindowsMediaPlayer();
        public Loadcs()
        {
            InitializeComponent();
            b.URL = "music2.mp3";
        }

        private void Loadcs_Load(object sender, EventArgs e)
        {
            b.controls.play();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 1;
            if(panel1.Width >= 599)
            {
                timer1.Stop();
                Form1 a = new Form1();
                a.Show();
                this.Hide();
                b.controls.stop();
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

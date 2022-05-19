using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace imdbproj
{
    public partial class OPTIONS : Form
    {
        public OPTIONS()
        {
            InitializeComponent();
        }        
        private void button_WOC1_Click(object sender, EventArgs e)
        {
            WatchList watchlist = new WatchList();
            watchlist.Show();
            this.Hide();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            UpdateRatings updateRatings = new UpdateRatings();
            updateRatings.Show();
            this.Hide();
        }

        private void button_WOC4_Click(object sender, EventArgs e)
        {
            loginForm lf = new loginForm();
            lf.Show();
            this.Close();
        }

        private void button_WOC5_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
            this.Close();
        }

        private void button_WOC6_Click(object sender, EventArgs e)
        {
            Rating fr = new Rating();
            fr.Show();
            this.Close();

        }
    }
}

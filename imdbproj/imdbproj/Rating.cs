using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace imdbproj
{
    public partial class Rating : Form
    {
        CrystalReport3 Nesr_el_magal;
        public Rating()
        {
            InitializeComponent();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.ReportSource = Nesr_el_magal;
        }

        private void Rating_Load(object sender, EventArgs e)
        {
            Nesr_el_magal = new CrystalReport3();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            OPTIONS op = new OPTIONS();
            op.Show();
            this.Close();
        }
    }
}

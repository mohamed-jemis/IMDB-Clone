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
    public partial class Form2 : Form
    {
        CrystalReport1 Nesr_el_magal;
        public Form2()
        {
            InitializeComponent();
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            Nesr_el_magal = new CrystalReport1();
        }
        private void button_WOC6_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.ReportSource = Nesr_el_magal;
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            OPTIONS op = new OPTIONS();
            op.Show();
            this.Close();
        }
    }
}

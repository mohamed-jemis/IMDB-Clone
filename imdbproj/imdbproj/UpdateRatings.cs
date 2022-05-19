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
    public partial class UpdateRatings : Form
    {
        OracleDataAdapter adapter;
        DataTable ds;
        OracleCommandBuilder builder;
        public UpdateRatings()
        {
            InitializeComponent();
        }
        private void UpdateRatings_Load(object sender, EventArgs e)
        {
            string constr = "User Id=scott;Password=tiger;Data Source=orcl";
            string cmdstr = "Select FILMID , USERRATING,userid from RATINGS where USERID = :i";
            //string cmdstr = "Select filmtitles.filmtitle,ratings.USERRATING,ratings.userid from RATINGS , filmtitles where USERID = :i and filmtitles.filmid=ratings.filmid";
            adapter = new OracleDataAdapter(cmdstr, constr);
            //variable having the userID
            adapter.SelectCommand.Parameters.Add("i", loginForm.userId);
            ds = new DataTable();
            adapter.Fill(ds);
            //name of the gridview 
            //dataGridView1.ColumnCount = 1;
            dataGridView1.DataSource = ds;
            dataGridView1.Columns[2].Visible = false;
            
            
            

        }         
        
        private void button_WOC1_Click(object sender, EventArgs e)
        {
            
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds);           
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            OPTIONS op = new OPTIONS();
            op.Show();
            this.Close();
        }      
    }
}

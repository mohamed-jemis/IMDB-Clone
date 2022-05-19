
using Oracle.DataAccess.Client;
using System;
using System.Data;
using System.Windows.Forms;



namespace imdbproj
{
    public partial class WatchList : Form
    {

        string ordb = "Data Source=ORCL; User Id=scott; Password=tiger";
        int filmID = 1;
        OracleConnection conn;
        String userid = loginForm.userId;
        String filmtitle = "";
        public WatchList()
        {
            InitializeComponent();
        }

        private void WatchList_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();


            //adding all movies 

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select FIlMTITLE from FILMTITLES";//selects all movie titles 
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                //MessageBox.Show(dr[0].ToString());
                comboBox2.Items.Add(dr[0]);
            }
            dr.Close();

            //command responsible for the current user watch list


            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select filmId from watchlist where userid=:Id";//here we change the name of the bind variable to match with the other forms
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("Id", loginForm.userId.ToString());//here do the same change as in line 45
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                //retrive filmtitle
                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "select filmtitle from filmtitles where filmid=:Id";
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.Add("Id", int.Parse(dr2[0].ToString()));
                OracleDataReader dr3 = cmd3.ExecuteReader();
                while (dr3.Read())
                {
                    comboBox1.Items.Add(dr3[0]);
                }
            }
            dr2.Close();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RETRIVING THE CURRENT FILM ID THAT IS CHOSEN FROM THE COMBO BOX AND STORES IT IN filmID
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select filmId from FILMTITLES where FILMTITLE=:TITLE";//will be updated 
            cmd2.Parameters.Add("TITLE", comboBox2.SelectedItem.ToString());
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                filmID = int.Parse(dr2[0].ToString());
                OracleCommand cmd3 = new OracleCommand();
                cmd3.Connection = conn;
                cmd3.CommandText = "select filmtitle from filmtitles where filmid=:Id";
                cmd3.CommandType = CommandType.Text;
                cmd3.Parameters.Add("Id", filmID);
                OracleDataReader dr3 = cmd3.ExecuteReader();
                while (dr3.Read())
                {
                    filmtitle = dr3[0].ToString();
                }
            }
            dr2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            //at button click the insertion is done and it is ensured that there is no dupilcates 

            if (!comboBox1.Items.Contains(filmtitle))
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "insert into WATCHLIST values(:USERID,:FILMID)";
                cmd.Parameters.Add("USERID", int.Parse(userid));
                cmd.Parameters.Add("FILMID", filmID);
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    comboBox1.Items.Add(filmtitle);
                }
            }
            else
                MessageBox.Show("already added");
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            OPTIONS options = new OPTIONS();
            options.Show();
            this.Close();
        }     
     
    }
}

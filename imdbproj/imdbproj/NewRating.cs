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
    public partial class Form1 : Form

    {
        string ordb = "Data Source=ORCL; User Id=scott; Password=tiger";
        OracleConnection conn;
        int filmID = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select FIlMTITLE from FILMTITLES";//selects all movie titles 
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RETRIVING THE CURRENT FILM IDEA THAT IS CHOSEN FROM THE COMBO BOX AND STORES IT IN filmID
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select filmId from FILMTITLES where FILMTITLE=:TITLE";//will be updated 
            cmd2.Parameters.Add("TITLE", comboBox1.SelectedItem.ToString());
            OracleDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                filmID = int.Parse(dr2[0].ToString());
            }
            dr2.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into ratings values(:USERID,:FILMID,:userrating)";
            cmd.Parameters.Add("USERID", loginForm.userId);//FROM THE PREVIOUS FORMS
            cmd.Parameters.Add("FILMID", filmID);
            cmd.Parameters.Add("userrating", textBox1.Text);
            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    //comboBox1.Items.Add((decimal)filmID);
                    MessageBox.Show("done");
                }

            }
            catch
            {
                MessageBox.Show("Already rated");
            }
        }
        private void button_WOC1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into ratings values(:USERID,:FILMID,:userrating)";
            cmd.Parameters.Add("USERID", loginForm.userId);//FROM THE PREVIOUS FORMS
            cmd.Parameters.Add("FILMID", filmID);
            cmd.Parameters.Add("userrating", textBox1.Text);
            try
            {
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    //comboBox1.Items.Add((decimal)filmID);
                    MessageBox.Show("Rating Complete");
                }

            }
            catch
            {
                MessageBox.Show("Invalid Format or Already Rated");
            }
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            OPTIONS options = new OPTIONS();
            options.Show();
            this.Close();
        }      
    }
}

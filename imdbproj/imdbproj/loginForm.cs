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


    public partial class loginForm : Form
    {
        string ordb = "Data Source=ORCL; User Id=scott; Password=tiger";
        OracleConnection conn;

        //Variable storing userId
        //To use it: loginForm.userId
        public static string userId = "";

        public loginForm()
        {
            InitializeComponent();
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select USERID from USERS where USERNAME=:username and PASS=:pass";

            cmd.Parameters.Add("username", textBox2.Text);
            cmd.Parameters.Add("pass", textBox1.Text);

            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                userId = dr[0].ToString();

            }
            // MessageBox.Show(userId);


            if (userId == "")
            {
                MessageBox.Show("Incorrect Username or Password!");
            }
            else
            {
                MessageBox.Show("nesr l magal ya welad l m*****");
                //userId = textBox2.Text;
                OPTIONS op = new OPTIONS();
                op.Show();
                this.Hide();

            }

            dr.Close();
        }

        private void loginForm_Close(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }
        private void button_WOC1_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select USERID from USERS where USERNAME=:username and PASS=:pass";

            cmd.Parameters.Add("username", textBox2.Text);
            cmd.Parameters.Add("pass", textBox1.Text);

            OracleDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                userId = dr[0].ToString();

            }
            // MessageBox.Show(userId);


            if (userId == "")
            {
                MessageBox.Show("Incorrect Username or Password!");
            }
            else
            {
                MessageBox.Show("Logged in بنجاح");
                //userId = textBox2.Text;
                OPTIONS op = new OPTIONS();
                op.Show();
                this.Hide();

            }

            dr.Close();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            this.Hide();
            signupForm signup = new signupForm();
            signup.ShowDialog();

        }

        private void button_WOC3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

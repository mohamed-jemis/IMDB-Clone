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
    public partial class signupForm : Form
    {
        string ordb = "Data Source=ORCL; User Id=scott; Password=tiger";
        OracleConnection conn;
        public signupForm()
        {
            InitializeComponent();
        }

        private void signupForm_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String userId = "";
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select USERID from USERS where USERNAME =:username";
            cmd1.Parameters.Add("username", textBox1.Text);
            OracleDataReader dr = cmd1.ExecuteReader();


            if (dr.Read())
            {
                userId = dr[0].ToString();

            }
          
            
            if (userId == "")
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into USERS values (UserID_seq.NEXTVAL, :USERNAME, :PASS)";

                cmd.Parameters.Add("USERNAME", textBox1.Text);
                cmd.Parameters.Add("PASS", textBox2.Text);

                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Signed up successfully!");
                    this.Hide();
                    loginForm login = new loginForm();
                    login.ShowDialog();

                }
            }

            else
            {
                
                MessageBox.Show("Username already exist!");
            }
                
            
        }

        private void signupForm_Close(object sender, FormClosingEventArgs e)
        {
            conn.Dispose();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginForm login = new loginForm();
            login.Show();
            this.Close();
        }

        private void button_WOC2_Click(object sender, EventArgs e)
        {
            loginForm login = new loginForm();
            login.Show();
            this.Close();
        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            String userId = "";
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "select USERID from USERS where USERNAME =:username";
            cmd1.Parameters.Add("username", textBox1.Text);
            OracleDataReader dr = cmd1.ExecuteReader();


            if (dr.Read())
            {
                userId = dr[0].ToString();

            }


            if (userId == "")
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into USERS values (UserID_seq.NEXTVAL, :USERNAME, :PASS)";

                cmd.Parameters.Add("USERNAME", textBox1.Text);
                cmd.Parameters.Add("PASS", textBox2.Text);

                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Signed up successfully!");
                    this.Hide();
                    loginForm login = new loginForm();
                    login.ShowDialog();

                }
            }

            else
            {

                MessageBox.Show("Username already exist!");
            }

        }    
    }
}

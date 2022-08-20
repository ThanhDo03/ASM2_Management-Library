using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsLoginStaff_Asm2
{
    public partial class LoginStaff : Form
    {

        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        public LoginStaff()
        {
            InitializeComponent();
            conn = new SqlConnection("server=THANHDO\\SQLEXPRESS;database=ASM2;uid=sa;pwd=tranvanthanh07@");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FBTEC_LIBRARY_ONLINE fBTEC_LIBRARY_ONLINE = new FBTEC_LIBRARY_ONLINE();
            this.Close();
            fBTEC_LIBRARY_ONLINE.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
               
                cmd = new SqlCommand();
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM AccountStaff where Userr='" + txtUser.Text + "'AND Pass='" + txtPass.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Logged in successfully","ThankYou!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    Missionn mission = new Missionn();
                    this.Close();
                    mission.Show();
                }
                else
                {
                    MessageBox.Show("Error,plese check the username and password again!!", "Sorry!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                conn.Close();
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void LoginStaff_Load(object sender, EventArgs e)
        {

        }
    }
}

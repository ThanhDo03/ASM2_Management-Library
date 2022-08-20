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
    public partial class LoginStudent : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public LoginStudent()
        {
            InitializeComponent();
            con = new SqlConnection("server=THANHDO\\SQLEXPRESS;database=ASM2;uid=sa;pwd=tranvanthanh07@");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string User = txtUser.Text;
                string Email = txtEmail.Text;
                string Pass = txtPass.Text;
                cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM AccountStudentt where UserName='" + txtUser.Text + "'AND Email='" + txtEmail.Text + "'AND PassWord='" + txtPass.Text + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Logged in successfully", "ThankYou!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    YourAccount yourAccount = new YourAccount(txtUser.Text, txtEmail.Text, txtPass.Text);
                    this.Hide();
                    yourAccount.Show();
                   
                }

                else
                {
                    MessageBox.Show("Error,plese check the username, email and password again!!", "Sorry!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                con.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            FBTEC_LIBRARY_ONLINE fBTEC_LIBRARY_ONLINE = new FBTEC_LIBRARY_ONLINE();
            this.Close();
            fBTEC_LIBRARY_ONLINE.Show();
        }

        private void labelForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            this.Close();
            forgotPassword.Show();
        }

        private void labelRegister_Click(object sender, EventArgs e)
        {
            RegisterStudent regis = new RegisterStudent();
            this.Close();
            regis.Show();
        }

        private void LoginStudent_Load(object sender, EventArgs e)
        {

        }
    }
}

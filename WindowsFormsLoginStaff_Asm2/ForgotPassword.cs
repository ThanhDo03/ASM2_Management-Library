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
    public partial class ForgotPassword : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public ForgotPassword()
        {
            InitializeComponent();
            con = new SqlConnection("server=THANHDO\\SQLEXPRESS;database=ASM2;uid=sa;pwd=tranvanthanh07@");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginStudent loginStudent = new LoginStudent();
            this.Close();
            loginStudent.Show();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM AccountStudentt where Email='" + txtEmail.Text + "'";
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        con.Close();
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "UPDATE AccountStudentt SET PassWord = @password where Email = '" + txtEmail.Text + "'";

                        cmd.Parameters.Add("@password", SqlDbType.VarChar, 30).Value = txtPass.Text;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Successful!", "Update");

                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    dr.Close();
                    con.Close();


                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void labelTF_Leave(object sender, EventArgs e)
        {
            // ERROR
        }

        private void labelF_Leave(object sender, EventArgs e)
        {
            // ERROR
        }

        private void txtVeriFPass_Leave(object sender, EventArgs e)
        {
            // ERROR
        }

        private void txtVeriFPass_TextChanged(object sender, EventArgs e)
        {
    
        }
        private void ForgotPassword_Load(object sender, EventArgs e)
        {
            // ERROR
        }
        private bool Check()
        {
            if (txtPass.Text != txtCPass.Text)
            {
                labelErrors.ForeColor = System.Drawing.Color.Red;
                labelErrors.Text = "New password and confirmation password do not match";
                txtCPass.Focus();
                txtCPass.SelectAll();
                return false;
            }
            else
            {
                labelErrors.Text = "";
                return true;
            }
        }
        private void txtEmail_Leave(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                labelWEmail.ForeColor = System.Drawing.Color.Red;
                labelWEmail.Text = "Please enter Email !!";
                btnSubmit.Enabled = false;
                txtEmail.Focus();
            }
            else
            {
                btnSubmit.Enabled = true;

            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if (txtEmail.Text != "")
            {
                labelWEmail.Text = "";
            }
        }

        private void checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox.Checked)
            {
                txtPass.PasswordChar = (char)0;
                txtCPass.PasswordChar = (char)0;

            }
            else
            {
                txtPass.PasswordChar = '*';
                txtCPass.PasswordChar = '*';
            }
        }
    }
}

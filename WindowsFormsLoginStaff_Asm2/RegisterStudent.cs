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
    public partial class RegisterStudent : Form
    {
        SqlConnection con;
        public RegisterStudent()
        {
            InitializeComponent();
            con = new SqlConnection("server=THANHDO\\SQLEXPRESS;database=ASM2;uid=sa;pwd=tranvanthanh07@");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginStudent loginStudent = new LoginStudent();
            this.Close();
            loginStudent.Show();

        }

        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPass.Checked)
            {
                txtPass.PasswordChar = (char)0;
                txtC_Pass.PasswordChar = (char)0;
            }
            else
            {
                txtPass.PasswordChar = '*';
                txtC_Pass.PasswordChar = '*';

            }
        }

        private void RegisterStudent_Load(object sender, EventArgs e)
        {
           
        }

        private void txtC_Pass_TextChanged(object sender, EventArgs e)
        {
            if (txtPass.Text == txtC_Pass.Text)
            {
                labelTF.Text = "✔";

            }
            else
            {
                labelTF.Text = "✘";
            }
        }

        private void txtC_Pass_Leave(object sender, EventArgs e)
        {
           
        }
        private bool CheckInfor()
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Please enter ID!!", "Warning");
                return false;
            }
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Please enter username!!", "Warning");
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please enter email!!", "Warning");
                return false;
            }
            if (txtPass.Text == "")
            {
                MessageBox.Show("Please enter password!!", "Warning");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckInfor())
            {
                try
                {
                    con.Close();
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO AccountStudentt VALUES (@StudentID, @UserName, @Email, @PassWord)";
                    cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = txtID.Text;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtUserName.Text;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                    cmd.Parameters.Add("@PassWord", SqlDbType.VarChar).Value = txtPass.Text;
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    
                    MessageBox.Show("New ACCOUNT added successfully!!", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
           
                catch (Exception ex)
                {
                    MessageBox.Show("ID must be in the form 123xxx", "Warning");
                }
                // 
                try
                {
                    con.Close();  
                    con.Open();
                    SqlCommand cmdd = new SqlCommand();
                    cmdd.CommandText = "INSERT INTO Studentt VALUES (@StudentID, @FullName,'','','')";
                    cmdd.Parameters.Add("@StudentID", SqlDbType.Int).Value = txtID.Text;
                    cmdd.Parameters.Add("@FullName", SqlDbType.Char).Value = txtUserName.Text;
                    cmdd.Connection = con;
                    cmdd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Warning");
                }


            }
        }
    }
}

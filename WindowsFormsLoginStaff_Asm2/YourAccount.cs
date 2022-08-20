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
    public partial class YourAccount : Form
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public YourAccount()
        {
            InitializeComponent();
            con = new SqlConnection("server=THANHDO\\SQLEXPRESS; database=ASM2;uid=sa;pwd=tranvanthanh07@");
        }
        private string Pass;
        public string ID;
        public YourAccount(string username, string email, string pass) : this()
        {
            UserName.Text = username;
            Email.Text = email;
            Pass = pass;
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            LoginStudent loginStudent = new LoginStudent();
            this.Hide();
            loginStudent.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void change1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void UserName_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "SELECT * FROM AccountStudentt where UserName='" + UserName.Text + "'AND PassWord='" + Pass + "'";
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        con.Close();
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "UPDATE AccountStudentt SET PassWord = @password where UserName = @username";

                        cmd.Parameters.Add("@username", SqlDbType.VarChar, 20).Value = UserName.Text;
                        cmd.Parameters.Add("@password", SqlDbType.VarChar, 30).Value = txtN_Pass.Text;
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

        private void labelChangePass_Click(object sender, EventArgs e)
        {
            labelO_Pass.Show();
            labelN_Pass.Show();
            labelC_Pass.Show();
            txtO_Pass.Show();
            txtN_Pass.Show();
            txtC_Pass.Show();
            btnSave.Show();
            btnClose.Show();
            labelIcon.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            labelO_Pass.Hide();
    
            labelN_Pass.Hide();
            labelC_Pass.Hide();
            txtO_Pass.Hide();
            txtO_Pass.Text = "";
            txtN_Pass.Hide();
            txtN_Pass.Text = "";
            txtC_Pass.Hide();
            txtC_Pass.Text = "";
            btnSave.Hide();
            btnClose.Hide();
            labelIcon.Hide();
        }

        private void txtO_Pass_TextChanged(object sender, EventArgs e)
        {
            if(Pass == txtO_Pass.Text)
            {
                labelIcon.Text = "✔";
            }
            else
            {
                labelIcon.Text = "";
            }
        }
        public bool Check()
        {
            if(txtO_Pass.Text == "")
            {
                labelInfor.ForeColor = System.Drawing.Color.Red;
                labelInfor.Text = "Please enter current password !!";
                txtO_Pass.Focus();
                return false;
            }
            else if (txtN_Pass.Text == "")
            {
                labelInfor.ForeColor = System.Drawing.Color.Red;
                labelInfor.Text = "Please enter a new password!!";
                txtN_Pass.Focus();
                return false;
            }
            else if (txtC_Pass.Text == "")
            {
                labelInfor.ForeColor = System.Drawing.Color.Red;
                labelInfor.Text = "Please confirm password !!";
                txtC_Pass.Focus();
                return false;
            }
            else if(txtN_Pass.Text != txtC_Pass.Text)
            {
                labelInfor.ForeColor = System.Drawing.Color.Red;
                labelInfor.Text = "New password and confirmation password do not match";
                txtC_Pass.Focus();
                txtC_Pass.SelectAll();
                return false;
            }
            return true;
        }
        private void txtN_Pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelTheLibrary_Click(object sender, EventArgs e)
        {
            LibraryFBTEC libraryFBTEC = new LibraryFBTEC(ID);
            //this.Close();
            libraryFBTEC.Show();
        }

        
       
        private void YourAccount_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT StudentID FROM AccountStudentt WHERE UserName ='" + UserName.Text + "'", con);
            DataTable mytable = new DataTable();
            adapter.Fill(mytable);
            labelShowID.Text = mytable.Rows[0]["StudentID"].ToString();

            ID = labelShowID.Text = mytable.Rows[0]["StudentID"].ToString();

            cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Studentt WHERE StudentID = '" + ID + "'";

            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                if (rdr.Read())
                {
                    labelShowClass.Text = rdr.GetString(2);
                }
            }
            else
            {

            }
            rdr.Close();
        }

        private void labelMess_Click(object sender, EventArgs e)
        {
            MessageStudent messageStudent = new MessageStudent(ID);
            messageStudent.Show();
        }

        private void labelChangePhone_Click(object sender, EventArgs e)
        {
            txtChangePhone.Show();
            btnSavePhone.Show();
            btnClosePhone.Show();
        }

        private void btnSavePhone_Click(object sender, EventArgs e)
        {

        }

        private void btnClosePhone_Click(object sender, EventArgs e)
        {
            txtChangePhone.Hide();
            btnSavePhone.Hide();
            btnClosePhone.Hide();
        }
    }
}

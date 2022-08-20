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
    public partial class AddBook : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public AddBook()
        {
            InitializeComponent();
            con = new SqlConnection("server=THANHDO\\SQLEXPRESS;database=ASM2;uid=sa;pwd=tranvanthanh07@");
        }

        private void AddBook_Load(object sender, EventArgs e)
        {

        }
        //private bool CheckInfor()
        //{
        //    if (txtAddID.Text == "")
        //    {
        //        txtAddID.Focus();
        //        btnADD.Enabled = false;
        //        MessageBox.Show("Please enter ID", "Warning");
               
        //        return false;
        //    }
        //    else if (txtAddCategory.Text == "")
        //    {
        //        txtAddCategory.Focus();
        //        btnADD.Enabled = false;
        //        MessageBox.Show("Please enter the Category", "Warning");
                
        //        return false;
        //    }
        //    else if (txtTitle.Text == "")
        //    {
        //        txtTitle.Focus();
        //        btnADD.Enabled = false;
        //        MessageBox.Show("Please enter Book title", "Warning");
               
        //        return false;
        //    }
        //    else if (txtPublishyear.Text == "")
        //    {
        //        txtPublishyear.Focus();
        //        btnADD.Enabled = false;
        //        MessageBox.Show("Please enter Book title", "Warning");
               
        //        return false;
        //    }
        //    else if (txtAddPublisher.Text == "")
        //    {
        //        txtAddPublisher.Focus();
        //        btnADD.Enabled = false;
        //        MessageBox.Show("Please enter Publisher", "Warning");
               
        //        return false;
        //    }
        //    else if (txtAddAuthor.Text == "")
        //    {
        //        txtAddAuthor.Focus();
        //        btnADD.Enabled = false;
        //        MessageBox.Show("Please enter Author", "Warning");
               
        //    }
        //    else if(txtAddBookcase.Text == "")
        //    {
        //        txtAddBookcase.Focus();
        //        btnADD.Enabled = false;
        //        MessageBox.Show("Plase enter Bookcase", "Warning");
               
        //        return false;
        //    }
        //    else if(txtAddRow.Text == "")
        //    {
        //        txtAddRow.Focus();
        //        btnADD.Enabled = false;
        //        MessageBox.Show("Please enter Row", "Warning");
               
        //        return false;

        //    }
        //    else if(txtAddPrice.Text == "")
        //    {
        //        txtAddPrice.Focus();
        //        btnADD.Enabled = false;
        //        MessageBox.Show("Please enter Price", "Warning");
               
        //        return false;
        //    }
        //    return true;
        //}
        private void btnADD_Click(object sender, EventArgs e)
        {

            con.Open();
            try
                {

                    SqlCommand cmd = con.CreateCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO BOOK VALUES (@bookID,@category,@booktitle,@publishingyear,@publisher,@author,@bookcase,@row,@price)";

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@bookID", SqlDbType.Char).Value = txtAddID.Text;
                    cmd.Parameters.Add("@category", SqlDbType.Char).Value = txtAddCategory.Text;
                    cmd.Parameters.Add("@booktitle", SqlDbType.Char).Value = txtTitle.Text;
                    cmd.Parameters.Add("@publishingyear", SqlDbType.Char).Value = txtPublishyear.Text;
                    cmd.Parameters.Add("@publisher", SqlDbType.Char).Value = txtAddPublisher.Text;
                    cmd.Parameters.Add("@author", SqlDbType.Char).Value = txtAddAuthor.Text;
                    cmd.Parameters.Add("@bookcase", SqlDbType.Int).Value = txtAddBookcase.Text;
                    cmd.Parameters.Add("@row", SqlDbType.Int).Value = txtAddRow.Text;
                    cmd.Parameters.Add("@price", SqlDbType.Int).Value = txtAddPrice.Text;


                    cmd.ExecuteNonQuery();


                    Reset();
                    MessageBox.Show("Successfully added new !!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            con.Close();


        }

        private void txtAddAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAddID_Leave(object sender, EventArgs e)
        {
            if(txtAddID.Text == "")
            {
                //txtAddID.Focus();
                btnADD.Enabled = false;
                MessageBox.Show("Please enter ID", "Warning");
            }
            else
            {
                btnADD.Enabled = true;
            }

            //
            con.Open();
            try
            {
                
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM BOOK WHERE BookID = '" + txtAddID.Text + "'";
                cmd.CommandType = CommandType.Text;

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        MessageBox.Show("Mã sách này đã tồn tại");
                        txtAddID.Focus();
                    }
                }
                else
                {

                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
            
        }

        private void txtAddCategory_Leave(object sender, EventArgs e)
        {
            if(txtAddCategory.Text == "")
            {
                //txtAddCategory.Focus();
                btnADD.Enabled = false;
                MessageBox.Show("Please enter the Category", "Warning");
            }
            else
            {
                btnADD.Enabled = true;
            }
            
        }

        private void txtTitle_Leave(object sender, EventArgs e)
        {
            if(txtTitle.Text == "")
            {
                //txtTitle.Focus();
                btnADD.Enabled = false;
                MessageBox.Show("Please enter Book title", "Warning");
            }
            else
            {
                btnADD.Enabled = true;
            }
            
        }

        private void txtPublishyear_Leave(object sender, EventArgs e)
        {
            if(txtPublishyear.Text == "")
            {
                //txtAddPublisher.Focus();
                btnADD.Enabled = false;
                MessageBox.Show("Please enter Publisher", "Warning");
            }
            else
            {
                btnADD.Enabled = true;
            }
          

        }

        private void txtAddPublisher_Leave(object sender, EventArgs e)
        {
            if(txtAddPublisher.Text == "")
            {
                //txtAddPublisher.Focus();
                btnADD.Enabled = false;
                MessageBox.Show("Please enter Publisher", "Warning");
            }
            else
            {
                btnADD.Enabled = true;
            }
          
        }

        private void txtAddAuthor_Leave(object sender, EventArgs e)
        {
            if (txtAddAuthor.Text == "") 
            {
                //txtAddAuthor.Focus();
                btnADD.Enabled = false;
                MessageBox.Show("Please enter Author", "Warning");
            }
            else
            {
                btnADD.Enabled = true;
            }
           

        }    
        private void txtAddBookcase_Leave(object sender, EventArgs e)
        {
            if(txtAddBookcase.Text == "")
            {
                //txtAddBookcase.Focus();
                btnADD.Enabled = false;
                MessageBox.Show("Plase enter Bookcase", "Warning");
            }
            else
            {
                btnADD.Enabled = true;
            }
           

        }

        private void txtAddRow_Leave(object sender, EventArgs e)
        {
            if(txtAddRow.Text == "")
            {
                //txtAddRow.Focus();
                btnADD.Enabled = false;
                MessageBox.Show("Please enter Row", "Warning");
            }
            else
            {
                btnADD.Enabled = true;
            }
           
        }

        private void txtAddPrice_Leave(object sender, EventArgs e)
        {
            if(txtAddPrice.Text == "")
            {
                //txtAddPrice.Focus();
                btnADD.Enabled = false;
                MessageBox.Show("Please enter Price", "Warning");
            }
            else
            {
                btnADD.Enabled = true;
            }
           

        }
        private void Reset()
        {
            txtAddID.Text = "";
            txtAddCategory.Text = "";
            txtTitle.Text = "";
            txtPublishyear.Text = "";
            txtAddPublisher.Text = "";
            txtAddAuthor.Text = "";
            txtAddBookcase.Text = "";
            txtAddRow.Text = "";
            txtAddPrice.Text = "";
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void txtAddID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

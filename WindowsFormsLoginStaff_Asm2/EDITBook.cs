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
    public partial class EDITBook : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader dr;
        public EDITBook()
        {
            InitializeComponent();
            con = new SqlConnection("server=THANHDO\\SQLEXPRESS;database=ASM2;uid=sa;pwd=tranvanthanh07@");
        }
        private string ID;
        public EDITBook(string Id): this()
        {
            ID = Id;
            labelShowBookID.Text = ID;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }

        private void labelShowBookID_Click(object sender, EventArgs e)
        {
            
        }

        private void EDITBook_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM BOOK WHERE BookID = '" + ID + "'";
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                if (dr.Read())
                {
                    labelCa.Text = dr.GetString(1);
                    labelBookTitle.Text = dr.GetString(2);
                    labelPubYear.Text = dr.GetString(3);
                    labelPub.Text = dr.GetString(4);
                    labelAu.Text = dr.GetString(5);
                    labelBCase.Text = Convert.ToString(dr.GetInt32(6));
                    labelRow.Text = Convert.ToString(dr.GetInt32(7));
                    labelPrice.Text = Convert.ToString(dr.GetInt32(8));
                }

            }
            con.Close();
        }

        private void txtPublisher_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Are you sure you want to edit the information of the book??", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                txtShowCa.Show();
                txtShowBook.Show();
                txtShowYear.Show();
                txtPublisher.Show();
                txtAuthor.Show();
                txtBookCase.Show();
                txtRow.Show();
                txtPrice.Show();
                btnClose.Show();
                btnSave.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            txtShowCa.Hide();
            txtShowBook.Hide();
            txtShowYear.Hide();
            txtPublisher.Hide();
            txtAuthor.Hide();
            txtBookCase.Hide();
            txtRow.Hide();
            txtPrice.Hide();
            btnClose.Hide();
            btnSave.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "UPDATE BOOK SET Cetegory=@cetegory, BookTitle=@bookTitle,Publishingyear=@publishingyear," +
                    "Publisher=@publisher,Author=@author,Bookcase=@bookcase,Row=@row,Price=@price WHERE BookID = '" + ID + "'";
                
                
                cmd.Parameters.Add("@cetegory", SqlDbType.Char, 20).Value = txtShowCa.Text;
                cmd.Parameters.Add("@bookTitle", SqlDbType.Char, 20).Value = txtShowBook.Text;
                cmd.Parameters.Add("@publishingyear", SqlDbType.Char, 20).Value = txtShowYear.Text;
                cmd.Parameters.Add("@publisher", SqlDbType.Char, 20).Value = txtPublisher.Text;
                cmd.Parameters.Add("@author", SqlDbType.Char, 20).Value = txtAuthor.Text;
                cmd.Parameters.Add("@bookcase", SqlDbType.Int).Value = txtBookCase.Text;
                cmd.Parameters.Add("@row", SqlDbType.Int).Value = txtRow.Text;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = txtPrice.Text;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your editing has been successful!!", "EDIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        private void labelCa_Click(object sender, EventArgs e)
        {

        }
    }
}

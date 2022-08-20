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
    public partial class LibraryFBTEC : Form
    {
        SqlConnection con;
        
        public LibraryFBTEC()
        {
            InitializeComponent();
            con = new SqlConnection("server=THANHDO\\SQLEXPRESS;database=ASM2;uid=sa;pwd=tranvanthanh07@"); 
        }
        
        public LibraryFBTEC(string id): this()
        {
            ShowID.Text = id;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            //YourAccount yourAccount = new YourAccount();
            this.Close();
            //yourAccount.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void connectdatasql()
        {
            con.Open();
            string sql = "SELECT * FROM BOOK";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt; 
        }

        private void LibraryFBTEC_Load(object sender, EventArgs e)
        {
            connectdatasql();
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //sử dụng thuộc tính RowFilter để tìm kiếm theo tên "Name"
            string rowFilter = string.Format("{0} like '{1}'", "BookTitle", "*" + txtSearch.Text + "*");
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.Rows[e.RowIndex];
                txtIDBook.Text = Convert.ToString(row.Cells["BookID"].Value);
                
                try
                {
                    con.Open();
                    SqlCommand cmds = new SqlCommand();
                    cmds.CommandText = "SELECT * FROM REQUEST WHERE BookID = '" + txtIDBook.Text + "'";

                    cmds.Connection = con;
                    SqlDataReader dr = cmds.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            MessageBox.Show("This book has been borrowed or is awaiting confirmation!!", "Request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    dr.Close();
                    con.Close();
                }
                catch(Exception ex) { MessageBox.Show(ex.Message, "Error"); }
                

            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {

            if(txtIDBook.Text == "")
            {
                MessageBox.Show("Choose the book you want!!", "Warning" , MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else 
            {
                con.Close();
                con.Open();
                try
                {
                    
                    SqlCommand cmdd = new SqlCommand();
                    //cmdd.CommandText = "SELECT * FROM(SELECT COUNT(StudentID) as SID FROM REQUEST WHERE StudentID = '" + ShowID.Text + "') AS e  WHERE SID > 2";
                    cmdd.CommandText = "SELECT * FROM REQUEST WHERE StudentID ='" + ShowID.Text + "'";
                    cmdd.Connection = con;
                    
                    SqlDataReader drr = cmdd.ExecuteReader();
                    if (drr.HasRows)
                    {
                        if (drr.Read())
                        {
                            MessageBox.Show("You have borrowed more books than allowed!!!", "Request", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        con.Close();
                        con.Open();
                        try
                        {
                            SqlCommand cmdc = new SqlCommand();
                            cmdc.CommandText = "INSERT INTO REQUEST (BookID,StudentID) VALUES ('" + txtIDBook.Text + "','" + ShowID.Text + "')";
                            cmdc.Connection = con;
                            //con.Open();
                            cmdc.ExecuteNonQuery();
                            //con.Close();
                            MessageBox.Show("Your request has been sent to the Librarian!!", "Request", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error");
                        }
                        con.Close();

                    }
                    drr.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
                con.Close();
            }
        }

        private void ShowID_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

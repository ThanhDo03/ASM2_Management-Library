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
    public partial class MessageStudent : Form
    {
        SqlConnection con;
        public MessageStudent()
        {
            InitializeComponent();
            con = new SqlConnection("server=THANHDO\\SQLEXPRESS; database=ASM2;uid=sa;pwd=tranvanthanh07@");
        }
        private string ID;
        public MessageStudent(string id) : this()
        {
            ID = id;
            labelShowSID.Text = id;
        }
        private void MessageStudent_Load(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT * FROM BorrowBookStudent WHERE StudentID = '" + ID + "'";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        labelShowBorrow.Text = dr.GetString(0);
                        labelShowStaffID.Text = Convert.ToString(dr.GetInt32(1));
                        labelShowBookID.Text = dr.GetString(2);
                        labelShowBorrowDate.Text = Convert.ToString(dr.GetDateTime(4));
                        labelShowReturnDate.Text = Convert.ToString(dr.GetDateTime(5));
                        labelShowMess.Text = dr.GetString(6);
                    }
                }
                else
                {
                    labelShowBorrow.Text = "Load...";
                    labelShowStaffID.Text = "Load...";
                    labelShowBookID.Text = "Load...";
                    labelShowBorrowDate.Text = "Load...";
                    labelShowReturnDate.Text = "Load...";
                    labelShowMess.Text = "Load...";
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

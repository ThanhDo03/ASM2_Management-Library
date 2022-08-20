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
    public partial class Missionn : Form
    {
        //Account Student
        SqlConnection con;
        public Missionn()
        {
            InitializeComponent();
            con = new SqlConnection("server=THANHDO\\SQLEXPRESS;database=ASM2;uid=sa;pwd=tranvanthanh07@");
        }

        private void Missionn_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnDELETE_Click(object sender, EventArgs e)
        {

        }

        private void btnADD_Click(object sender, EventArgs e)
        {

        }
        // Account
        private void Account_Click(object sender, EventArgs e)
        {
            ShowAccount();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Do you want to escape?", "Notify", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                //Application.Exit();
                LoginStaff loginStaff = new LoginStaff();
                this.Close();
                loginStaff.Show();
            }
        }

        private void MissionFBTEC_SelectedIndexChanged(object sender, EventArgs e)
        {
           // 
        }

        private void Student_Click(object sender, EventArgs e)
        {

        }

        private void btnResetAccount_Click(object sender, EventArgs e)
        {
            ResetAccount();
        }
        private void ResetAccount()
        {
            txtEmailAccount.Text = "";
            txtIDAccount.Text = "";
            txtNameAccount.Text = "";
            txtPasswordAccount.Text = "";
        }
        private void ShowAccount()
        {

            try
            {
                con.Open();
                string sql = "SELECT * FROM AccountStudentt";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter Ad = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                Ad.Fill(table);

                dataGridViewAccount.DataSource = table;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDELETEAccount_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE AccountStudentt WHERE StudentID='" + txtIDAccount.Text + "'";
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ShowAccount();
                ResetAccount();
                MessageBox.Show("Account Deleted!!!!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEDITAccount_Click(object sender, EventArgs e)
        {
            if (txtIDAccount.Text == "")
            {
                MessageBox.Show("Please enter the student ID to correct!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDAccount.Focus();
            }
            else if (CheckAccount())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE AccountStudentt SET UserName = @username, Email = @email, PassWord = @password WHERE StudentID = '" + txtIDAccount.Text + "'";
                    //cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = txtNameAccount.Text;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = txtNameAccount.Text;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = txtEmailAccount.Text;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = txtPasswordAccount.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ShowAccount();
                    ResetAccount();
                    MessageBox.Show("Account has been UPDATE!!", "EDIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public bool CheckAccount()
        {
            if (txtIDAccount.Text == "")
            {
                MessageBox.Show("Please enter ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDAccount.Focus();
                return false;
            }
            if (txtNameAccount.Text == "")
            {
                MessageBox.Show("Please enter Username!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameAccount.Focus();
                return false;
            }
            if (txtEmailAccount.Text == "")
            {
                MessageBox.Show("Please enter Email!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmailAccount.Focus();
                return false;
            }
            if (txtPasswordAccount.Text == "")
            {
                MessageBox.Show("Please enter a Password!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPasswordAccount.Focus();
                return false;
            }
            return true;
        }

        private void btnADDAccount_Click(object sender, EventArgs e)
        {
            if (CheckAccount())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO AccountStudentt VALUES (@StudentID, @UserName, @Email, @PassWord)";
                    cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = txtIDAccount.Text;
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = txtNameAccount.Text;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmailAccount.Text;
                    cmd.Parameters.Add("@PassWord", SqlDbType.VarChar).Value = txtPasswordAccount.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ShowAccount();
                    ResetAccount();
                    MessageBox.Show("New ACCOUNT added successfully!!", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
        

        private void txtSearchAccount_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "UserName", "*" + txtSearchAccount.Text + "*");
            (dataGridViewAccount.DataSource as DataTable).DefaultView.RowFilter = rowFilter;

            string Filter = string.Format("{0} like '{1}'", "Email", "*" + txtSearchAccount.Text + "*");
            (dataGridViewAccount.DataSource as DataTable).DefaultView.RowFilter = Filter;
        }

        private void dataGridViewAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridViewAccount.Rows[e.RowIndex];
            txtIDAccount.Text = Convert.ToString(row.Cells["StudentID"].Value);
            txtNameAccount.Text = Convert.ToString(row.Cells["UserName"].Value);
            txtEmailAccount.Text = Convert.ToString(row.Cells["Email"].Value);
            txtPasswordAccount.Text = Convert.ToString(row.Cells["PassWord"].Value);
            if (e.RowIndex >= 0)
            {
                btnEDITAccount.Enabled = true;
                btnDELETEAccount.Enabled = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {           
            dataGridViewAccount.Refresh();
            ShowAccount();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEXIT_Click(object sender, EventArgs e)
        {

        }

        private void btnEDIT_Click(object sender, EventArgs e)
        {

        }
        // Student
        private void btnEXITStudent_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Do you want to escape?", "Notify", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dg == DialogResult.OK)
            {
                //Application.Exit();
                LoginStaff login = new LoginStaff();
                this.Close();
                login.Show();
            }
        }

        private void txtSearchStudent_TextChanged(object sender, EventArgs e)
        {
            string search = string.Format("{0} like '{1}'", "StudentName", "*" + txtSearchStudent.Text + "*");
            (dataGridViewStudent.DataSource as DataTable).DefaultView.RowFilter = search;
        }
        private void ShowStudent()
        {
            try
            {
                con.Open();
                string sql = "SELECT * FROM Studentt";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter dr = new SqlDataAdapter(cmd);
                DataTable tb = new DataTable();
                dr.Fill(tb);
                dataGridViewStudent.DataSource = tb;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private bool CheckInforStudent()
        {
            if (txtIDStudent.Text == "")
            {
                MessageBox.Show("Please enter ID!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDStudent.Focus();
                return false;
            }
            if (txtNameStudent.Text == "")
            {
                MessageBox.Show("Please enter Name!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNameStudent.Focus();
                return false;
            }
            if (txtPhoneNumberStudent.Text == "")
            {
                MessageBox.Show("Please enter PhoneNumber!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhoneNumberStudent.Focus();
                return false;
            }

            return true;
        }

        private void ResetStudent()
        {
            txtIDStudent.Text = "";
            txtNameStudent.Text = "";
            txtPhoneNumberStudent.Text = "";
        }

        private void btnADDStudent_Click(object sender, EventArgs e)
        {
            if (CheckInforStudent())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "INSERT INTO Studentt VALUES (@StudentID, @FullName, @PhoneNumber)";
                    cmd.Parameters.Add("@StudentID", SqlDbType.Int).Value = txtIDStudent.Text;
                    cmd.Parameters.Add("@FullName", SqlDbType.Char).Value = txtNameStudent.Text;
                    cmd.Parameters.Add("@PhoneNumber", SqlDbType.Char).Value = txtPhoneNumberStudent.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ShowStudent();
                    ResetStudent();
                    MessageBox.Show("Student has been successfully added!!", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void btnResetStudent_Click(object sender, EventArgs e)
        {
            ResetStudent();
        }

        private void btnDELETEStudent_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE Studentt WHERE StudentID='" + txtIDStudent.Text + "'";
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ShowStudent();
                ResetStudent();
                MessageBox.Show("Deleted!!!!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEDITStudent_Click(object sender, EventArgs e)
        {
            if (CheckInforStudent())
            {
                try
                {

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "UPDATE Studentt SET FullName = @name, PhoneNumber = @phone WHERE StudentID = '" + txtIDStudent.Text + "'";

                    cmd.Parameters.Add("@name", SqlDbType.Char).Value = txtNameStudent.Text;
                    cmd.Parameters.Add("@phone", SqlDbType.Char).Value = txtPhoneNumberStudent.Text;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ShowStudent();
                    ResetStudent();
                    MessageBox.Show("Student's Information has been UPDATE!!", "EDIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridViewStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }
        private void dataGridViewStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridViewStudent.Rows[e.RowIndex];
                txtIDStudent.Text = Convert.ToString(row.Cells[0].Value);
                txtNameStudent.Text = Convert.ToString(row.Cells[1].Value);
                txtPhoneNumberStudent.Text = Convert.ToString(row.Cells[2].Value);
            }
        }

        private void btnRefreshStudent_Click(object sender, EventArgs e)
        {
            dataGridViewStudent.Refresh();
            ShowStudent();
        }

        private void btnDe_Click(object sender, EventArgs e)
        {

        }

        private void btnCon_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // Borrow
        private void btnExitBorrow_Click(object sender, EventArgs e)
        {
            LoginStaff login = new LoginStaff();
            this.Close();
            login.Show();
        }
        private void ResetBorrow()
        {
            txtBorrowIDBorrow.Text = "";
            txtStaffIDBorrow.Text = "";
            labelBookIDBorrow.Text = "";
            labelSIDBorrow.Text = "";
            txtAddInforBorrow.Text = "";
        }

        private void btnUpdateBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "UPDATE BorrowBookStudent SET BorrowID = @borrowID, StaffID = @staff, BorrowedDate = @borrowedDate, ReturnDate = @returnDate, Message = @mess WHERE BorrowID ='" + txtBorrowIDBorrow.Text + "'";
                cmd.Parameters.Add("@borrowID", SqlDbType.Char).Value = txtBorrowIDBorrow.Text;
                cmd.Parameters.Add("@staff", SqlDbType.Char).Value = txtStaffIDBorrow.Text;
                cmd.Parameters.Add("@borrowedDate", SqlDbType.Date).Value = DateBorrow.Value;
                cmd.Parameters.Add("@returnDate", SqlDbType.Date).Value = DateReturn.Value;
                cmd.Parameters.Add("@mess", SqlDbType.Char).Value = txtAddInforBorrow.Text;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Refresh();
                ResetBorrow();
                MessageBox.Show("UPDATED!!", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void ShowRequest()
        {
            try
            {
                con.Open();
                string sql = "SELECT * FROM REQUEST";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                dataGridView2Borrow.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnRefreshBorrow_Click(object sender, EventArgs e)
        {
            dataGridView1Borrow.Refresh();
            dataGridView2Borrow.Refresh();
            ShowRequest();
            ShowBorrow();
        }

        private void ShowBorrow()
        {
            try
            {
                con.Open();
                string sql1 = "SELECT * FROM BorrowBookStudent";
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                cmd1.CommandType = CommandType.Text;
                SqlDataAdapter Ad = new SqlDataAdapter(cmd1);
                DataTable table = new DataTable();
                Ad.Fill(table);
                con.Close();
                dataGridView1Borrow.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnConBorrow_Click(object sender, EventArgs e)
        {
            if (txtBorrowIDp1Borrow.Text == "")
            {
                MessageBox.Show("You need to fill in BorrowID information.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {

                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.CommandText = "INSERT INTO BorrowBookStudent (BorrowID, BookID, StudentID) VALUES ('" + txtBorrowIDp1Borrow.Text + "','" + txtGetBookIDBorrow.Text + "','" + txtGetStudentIDBorrow.Text + "')";
                    cmd2.CommandType = CommandType.Text;
                    con.Open();
                    cmd2.Connection = con;
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Confirmed!!!!", "Request", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }

                try
                {
                    SqlCommand cmd3 = new SqlCommand();
                    cmd3.CommandText = "UPDATE REQUEST SET Description = 'Confirmed' WHERE BookID='" + txtGetBookIDBorrow.Text + "'";
                    con.Open();
                    cmd3.Connection = con;
                    cmd3.ExecuteNonQuery();
                    con.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void dataGridView2Borrow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView2Borrow.Rows[e.RowIndex];
                btnConBorrow.Enabled = true;
                txtGetBookIDBorrow.Text = Convert.ToString(row.Cells[0].Value);
                txtGetStudentIDBorrow.Text = Convert.ToString(row.Cells[1].Value);
                
            }
        }

        private void btnDeBorrow_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM REQUEST";
                con.Open();
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void txtSearchBorrow_TextChanged(object sender, EventArgs e)
        {
            string search = string.Format("{0} like '{1}'", "BookID", "*" + txtSearchBorrow.Text + "*");
            (dataGridView2Borrow.DataSource as DataTable).DefaultView.RowFilter = search;
        }

        private void dataGridView1Borrow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1Borrow.Rows[e.RowIndex];

                txtBorrowIDBorrow.Text = Convert.ToString(row.Cells[0].Value);
                txtStaffIDBorrow.Text = Convert.ToString(row.Cells[1].Value);
                labelBookIDBorrow.Text = Convert.ToString(row.Cells[2].Value);
                labelSIDBorrow.Text = Convert.ToString(row.Cells[3].Value);
            }
        }

        private void btnDeleteBorrow_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DELETE FROM BorrowBookStudent";
            con.Open();
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        // Book
        private void ShowBook()
        {
            con.Close();
            con.Open();

            string sql = "SELECT * FROM BOOK";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            dataGridViewBook.DataSource = dt;
        }
        private void btnExitBook_Click(object sender, EventArgs e)
        {
            LoginStaff loginSta = new LoginStaff();
            this.Close();
            loginSta.Show();
        }

        private void btnRefreshBook_Click(object sender, EventArgs e)
        {
            dataGridViewBook.Refresh();
            ShowBook();
        }

        private void txtSearchBook_TextChanged(object sender, EventArgs e)
        {
            string rowFilter = string.Format("{0} like '{1}'", "BookTitle", "*" + txtSearchBook.Text + "*");
            (dataGridViewBook.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBook addBook = new AddBook();
            //this.Close();
            addBook.Show();
        }

        private void dataGridViewBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridViewBook.Rows[e.RowIndex];
                EDITBook eDITBook = new EDITBook(row.Cells[0].Value.ToString());
                //this.Close();
                eDITBook.Show();
            }
        }

        // Librarian
        private void DataLibrarian()
        {
            
                con.Close();
                con.Open();

                string sql = "SELECT_Staff";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter rdr = new SqlDataAdapter(cmd);
                DataTable tabledata = new DataTable();
                rdr.Fill(tabledata);
                con.Close();
                dataGridViewLibrarian.DataSource = tabledata;
           
        }
        private bool CheckDataLibrarian()
        {
            if (txtUserNameLibrarian.Text == "")
            {
                MessageBox.Show("Please enter username!!","Warning");
                return false;
            }
            if (txtPasswordLibrarian.Text == "")
            {
                MessageBox.Show("Please enter username!!", "Warning");
                return false;
            }
            return true;
        }
        private void tabPage1_Click(object sender, EventArgs e)
        {
            dataGridViewLibrarian.Refresh();
            DataLibrarian();
            txtUserNameLibrarian.Text = "";
            txtPasswordLibrarian.Text = "";

        }

       

        private void btnRefreshLibrarian_Click(object sender, EventArgs e)
        {
            dataGridViewLibrarian.Refresh();
            DataLibrarian();
        }

        private void dataGridViewLibrarian_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //

        }

        private void dataGridViewLibrarian_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        private void btnExitLibrarian_Click(object sender, EventArgs e)
        {
            LoginStaff loginStaff = new LoginStaff();
            this.Close();
            loginStaff.Show();
        }

        private void btnAddLibrarian_Click(object sender, EventArgs e)
        {
            if (CheckDataLibrarian())
            {
               
                try
                {
               
                    con.Close();
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "INSERT INTO AccountStaff VALUES(@Userr, @Pass)";
                    cmd.Parameters.Add("@Userr", SqlDbType.VarChar).Value = txtUserNameLibrarian.Text;
                    cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = txtPasswordLibrarian.Text;
                    cmd.ExecuteNonQuery();
                    con.Close();
                    DataLibrarian();
                    MessageBox.Show("Added new librarian!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridViewLibrarian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridViewLibrarian.Rows[e.RowIndex];
                txtUserNameLibrarian.Text = Convert.ToString(row.Cells["Userr"].Value);
                txtPasswordLibrarian.Text = Convert.ToString(row.Cells["Pass"].Value);
            }
        }

        private void btnDeleteLibrarian_Click(object sender, EventArgs e)
        {
            
            try
            {
               
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE AccountStaff WHERE Userr='" + txtUserNameLibrarian.Text + "'";
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                DataLibrarian();
                MessageBox.Show("Deleted!!!!", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
           
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsLoginStaff_Asm2
{
    public partial class FBTEC_LIBRARY_ONLINE : Form
    {
        public FBTEC_LIBRARY_ONLINE()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // Create Student button
        private void btnStudent_Click(object sender, EventArgs e)
        {
            LoginStudent FromStudent = new LoginStudent();
            this.Hide();
            FromStudent.Show();
        }
        // Create Staff button
        private void btnStaff_Click(object sender, EventArgs e)
        {
            LoginStaff FromStaff = new LoginStaff();
            this.Hide();
            FromStaff.Show();
        }

        // Create program exit button
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

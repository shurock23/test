using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        BusinessLayer.blUserAdmin blUser = new BusinessLayer.blUserAdmin();       
        DataTable dt;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            dt = blUser.getLogin(txtUsername.Text, txtPassword.Text);

            if (dt.Rows.Count > 0)
            {
                this.Hide();
                frmMain frm = new frmMain();
                frm.populateData(dt.Rows[0]["Username"].ToString(), dt.Rows[0]["Firstname"].ToString(), dt.Rows[0]["Position"].ToString(), dt.Rows[0]["UserPassword"].ToString());
                blUser.UpdateAuditTrail(dt.Rows[0]["username"].ToString(), "Login Form", "Login","", dt.Rows[0]["Username"].ToString());
               
                MessageBox.Show("Login Successfuly", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm.Show();
            }

            else
            {
                MessageBox.Show("invalid account", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.label1.Parent = pictureBox1;
            this.label2.Parent = pictureBox1;           
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            
            txtPassword.Text = "sa";
            txtUsername.Text = "sa";
        }
    }
}
